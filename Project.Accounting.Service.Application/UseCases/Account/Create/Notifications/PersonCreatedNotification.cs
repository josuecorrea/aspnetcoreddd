using MediatR;

namespace Project.Accounting.Service.Application.UseCases.Account.Create.Notifications
{
    public class PersonCreatedNotification : INotification
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
