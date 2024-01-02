using MassTransit;
using Microsoft.Extensions.Logging;
using Project.Accounting.Service.Domain.Contracts.Services;
using System.Net.Mime;

namespace Project.Accounting.Service.Infra.Services
{
    public class BrokerService : IBrokerService
    {
        private ILogger<BrokerService> _logger;
        private readonly IBus _bus;
        public readonly IPublishEndpoint _publishEndpoint;

        public BrokerService(ILogger<BrokerService> logger, IBus bus, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _bus = bus;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Publish<T>(T message, string queue)
        {
            try
            {
                Uri uri = new Uri($"queue:{queue}");
                var endPoint = await _bus.GetSendEndpoint(uri);

                var correlationId = Guid.NewGuid();

                await endPoint.Send(message, sendContext =>
                {
                    sendContext.CorrelationId = correlationId;
                    sendContext.ContentType = new ContentType("application/json");
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error ocurred while rabbitmq message publish! ERROR -> {ex}");
            }
        }
    }
}