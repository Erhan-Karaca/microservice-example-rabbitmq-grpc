using OncuService.Common;
using OncuService.Common.Events.Mail;
using OncuService.Common.Infrastructure;

namespace OncuService.Projections.MailService
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
            QueueFactory.CreateBasicConsumer().EnsureExchange(OncuServiceConstants.MailExchangeName).EnsureQueue(OncuServiceConstants.MailQueueName, OncuServiceConstants.MailExchangeName).Receive<SendMailEvent>(fav => {
                _logger.LogInformation($"Received Mail To: {fav.To} Subject: {fav.Subject} Message: {fav.Message}");
            }).StartConsuming(OncuServiceConstants.MailQueueName);
        }
    }
}