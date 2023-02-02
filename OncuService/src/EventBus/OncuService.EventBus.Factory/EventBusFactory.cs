using OncuService.EventBus.Base;
using OncuService.EventBus.Base.Abstraction;
using OncuService.EventBus.RabbitMQ;

namespace OncuService.EventBus.Factory
{
    public static class EventBusFactory
    {
        public static IEventBus Create(EventBusConfig config, IServiceProvider serviceProvider)
        {
            return config.EventBusType switch
            {
                EventBusType.AzureServiceBus => new EventBusRabbitMQ(config, serviceProvider), _ => new EventBusRabbitMQ(config, serviceProvider),
            };
        }
    }
}