using MediatR;

namespace Project.Accounting.Service.Application.UseCases.Account.Create.Notifications
{
    public class PersonCreatedNotificationHandler : INotificationHandler<PersonCreatedNotification>
    {
        public async Task Handle(PersonCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Notificação enviada {nameof(PersonCreatedNotification)}");
        }
    }
}