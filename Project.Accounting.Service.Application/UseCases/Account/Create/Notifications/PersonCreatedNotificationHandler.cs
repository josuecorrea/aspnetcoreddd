using MediatR;
using PersonCreatedNotificationEvent;
using Project.Accounting.Service.Domain.Contracts.Services;

namespace Project.Accounting.Service.Application.UseCases.Account.Create.Notifications
{
    public class PersonCreatedNotificationHandler : INotificationHandler<PersonCreatedNotification>
    {
        private readonly IBrokerService _brokerService;

        public PersonCreatedNotificationHandler(IBrokerService brokerService)
        {
            _brokerService = brokerService;
        }

        public async Task Handle(PersonCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Notificação enviada {nameof(PersonCreatedNotification)}");

            await _brokerService.Publish(notification, nameof(PersonCreatedNotification));
        }
    }
}