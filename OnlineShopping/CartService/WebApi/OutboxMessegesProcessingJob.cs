using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace OnlineShopping.CartService.WebApi;

public class OutboxMessegesConsumerJob(ILogger<OutboxMessegesConsumerJob> logger, IServiceProvider serviceProvider, IConnection? messageConnection) : BackgroundService
{
    private readonly ILogger<OutboxMessegesConsumerJob> _logger = logger;
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private IConnection? _messageConnection = messageConnection;
    private IModel? _messageChannel;
    private EventingBasicConsumer consumer;

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
        consumer.Received -= ProcessMessageAsync;
        _messageChannel?.Dispose();
    }

    private void ProcessMessageAsync(object? sender, BasicDeliverEventArgs args)
    {

        string messagetext = Encoding.UTF8.GetString(args.Body.ToArray());
        _logger.LogInformation("All products retrieved from the catalog at {now}. Message Text: {text}", DateTime.Now, messagetext);

        var message = args.Body;
    }
}
