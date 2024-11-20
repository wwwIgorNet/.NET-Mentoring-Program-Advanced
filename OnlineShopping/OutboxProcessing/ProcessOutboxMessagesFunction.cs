using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShopping.CatalogService.Infrastructure.Data;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace OutboxProcessing
{
    public class ProcessOutboxMessagesFunction(
        ILoggerFactory loggerFactory,
        ApplicationDbContext dbContext,
        IConnection queueConnection)
    {
        private readonly ILogger _logger = loggerFactory.CreateLogger<ProcessOutboxMessagesFunction>();
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly IConnection _queueConnection = queueConnection;

        [Function("ProcessOutboxMessagesFunction")]
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"Timer trigger function executed at: {DateTime.Now}");

            var messages = _dbContext.OutboxMessages
                .Where(x => x.CompleteTime == null)
                .OrderBy(x => x.CreationTime)
                .ToListAsync();

            // publish to queu
            using var channel = _queueConnection.CreateModel();

            channel.QueueDeclare(queue: "catalogEvents", durable: false, exclusive: false, autoDelete: false,
                arguments: null);

            foreach (var message in await messages)
            {
                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new 
                { 
                    message.EntetyId, 
                    message.Property, 
                    message.NewValue 
                }));

                channel.BasicPublish(exchange: string.Empty, routingKey: "catalogEvents", body: body);
                message.CompleteTime = DateTime.UtcNow;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
