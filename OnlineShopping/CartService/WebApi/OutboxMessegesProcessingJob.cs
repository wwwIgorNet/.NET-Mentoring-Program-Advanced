using System.Text;
using System.Text.Json.Nodes;
using OnlineShopping.CartService.WebApi.BLL;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace OnlineShopping.CartService.WebApi;

public class OutboxMessegesConsumerJob(
    ILogger<OutboxMessegesConsumerJob> logger, 
    IConnection messageConnection,
    ICartItemsService cartItemsService) : BackgroundService
{
    private readonly ILogger<OutboxMessegesConsumerJob> _logger = logger;
    private readonly IConnection _messageConnection = messageConnection;
    private IModel? _messageChannel;
    private EventingBasicConsumer? consumer;
    private readonly ICartItemsService _cartItemsService = cartItemsService;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        string queueName = "catalogEvents";

        _messageChannel = _messageConnection.CreateModel();
        _messageChannel.QueueDeclare(queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        consumer = new EventingBasicConsumer(_messageChannel);
        consumer.Received += ProcessMessageAsync;

        _messageChannel.BasicConsume(queue: queueName,
            autoAck: true,
            consumer: consumer);

        return Task.CompletedTask;
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await base.StopAsync(cancellationToken);
        if (consumer != null)
            consumer.Received -= ProcessMessageAsync;

        _messageChannel?.Dispose();
    }

    private void ProcessMessageAsync(object? sender, BasicDeliverEventArgs args)
    {
        string message = Encoding.UTF8.GetString(args.Body.ToArray());
        _logger.LogInformation("Retrieved changes from the catalog {message}", message);

        try
        {
            var json = JsonNode.Parse(message);
            var externalEntityId = json["EntetyId"].GetValue<int>();
            var property = json["Property"].GetValue<string>();
            var value = json["NewValue"].GetValue<string>();

            if (property.StartsWith("Product."))
            {
                var productProperty = property.Replace("Product.", "");
                var propertyToUpdate = productProperty switch
                {
                    "Url" => "Image",
                    _ => productProperty
                };
                _cartItemsService.UpdateProperty(externalEntityId, propertyToUpdate, value);
            }
            args.Redelivered = true;
        }
        catch(Exception ex)
        {
            args.Redelivered = false;
            _logger.LogError(ex, "Error during processing message");
        }
    }
}
