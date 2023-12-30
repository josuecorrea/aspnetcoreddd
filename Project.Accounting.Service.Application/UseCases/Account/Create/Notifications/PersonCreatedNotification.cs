using MediatR;

namespace PersonCreatedNotificationEvent
{
    public class PersonCreatedNotification : INotification
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
