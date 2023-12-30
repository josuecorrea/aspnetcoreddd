using MassTransit;

namespace Project.Accounting.Service.Api.Config
{
    public static class BrokerConfiguration
    {
        public static IServiceCollection AddBrokerConfiguration(this IServiceCollection services)
        {
             services.AddMassTransit(x =>
             {
                 //x.AddConsumer<>();

                 x.UsingRabbitMq((context, cfg) =>
                 {
                     cfg.Host(new Uri($"rabbitmq://localhost:5672"), h =>
                     {
                         h.Username("guest");
                         h.Password("guest");
                         h.PublisherConfirmation = true;
                     });

                     cfg.ReceiveEndpoint(e =>
                     {
                         e.Bind("notification_queue");
                         //e.ConfigureConsumeTopology = false;
                         //e.PrefetchCount = 2;
                         //e.UseMessageRetry(r => r.Interval(2, 100));
                         //e.ConfigureConsumer<NotificationConsumerDois>(context);
                         e.ConfigureConsumeTopology = false;
                     });

                     cfg.ConfigureEndpoints(context);
                 });
             });

            return services;
        }
    }
}
