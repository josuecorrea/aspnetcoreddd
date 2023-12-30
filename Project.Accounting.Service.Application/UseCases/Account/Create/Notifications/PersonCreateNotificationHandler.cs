using MediatR;
using PersonCreatedNotificationEvent;
using PersonCreateFailNotificationEvent;
using Project.Accounting.Service.Domain.Contracts.Services;

namespace Project.Accounting.Service.Application.UseCases.Account.Create.Notifications
{
    public class PersonCreateNotificationHandler : INotificationHandler<PersonCreatedNotification>,
                                                   INotificationHandler<PersonCreateFailNotification>
    {
        private readonly IBrokerService _brokerService;

        public PersonCreateNotificationHandler(IBrokerService brokerService)
        {
            _brokerService = brokerService;
        }

        public async Task Handle(PersonCreatedNotification notification, CancellationToken cancellationToken)
        {
            await _brokerService.Publish(notification, nameof(PersonCreatedNotification));
        }

        public async Task Handle(PersonCreateFailNotification notification, CancellationToken cancellationToken)
        {
            await _brokerService.Publish(notification, nameof(PersonCreateFailNotification));
        }
    }
}