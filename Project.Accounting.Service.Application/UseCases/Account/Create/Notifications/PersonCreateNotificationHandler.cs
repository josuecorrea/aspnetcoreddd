using MediatR;
using PersonCreatedNotificationEvent;
using PersonCreateFailNotificationEvent;
using Project.Accounting.Service.Domain.Commom;
using Project.Accounting.Service.Domain.Contracts.Services;
using Project.Accounting.Service.Domain.Entities.PersonAgg;

namespace Project.Accounting.Service.Application.UseCases.Account.Create.Notifications
{
    public class PersonCreateNotificationHandler : INotificationHandler<PersonCreatedNotification>,
                                                   INotificationHandler<PersonCreateFailNotification>
    {
        private readonly IBrokerService _brokerService;
        private readonly ICacheService _cacheService;

        public PersonCreateNotificationHandler(IBrokerService brokerService, ICacheService cacheService)
        {
            _brokerService = brokerService;
            _cacheService = cacheService;
        }

        public async Task Handle(PersonCreatedNotification notification, CancellationToken cancellationToken)
        {
            await _brokerService.Publish(notification, nameof(PersonCreatedNotification));
            await _cacheService.SetValue(notification.Person.Id.ToString(), notification.Person, CacheTimeDefinition.OneYear());
        }

        public async Task Handle(PersonCreateFailNotification notification, CancellationToken cancellationToken)
        {
            await _brokerService.Publish(notification, nameof(PersonCreateFailNotification));
        }
    }
}