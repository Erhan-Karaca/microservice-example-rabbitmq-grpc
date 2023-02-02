using OncuService.Common;
using OncuService.Common.Events.Sms;
using OncuService.Common.Infrastructure;

namespace OncuService.Projections.SmsService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            QueueFactory.CreateBasicConsumer().EnsureExchange(OncuServiceConstants.SmsExchangeName).EnsureQueue(OncuServiceConstants.SmsQueueName, OncuServiceConstants.SmsExchangeName).Receive<SendSmsEvent>(fav => {
                _logger.LogInformation($"Received Sms Phone: {fav.Phone} Message: {fav.Message}");
            }).StartConsuming(OncuServiceConstants.SmsQueueName);
        }
    }
}