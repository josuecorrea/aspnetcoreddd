using MediatR;
using Project.Accounting.Service.Domain.Entities.PersonAgg;

namespace PersonCreatedNotificationEvent
{
    public class PersonCreatedNotification : INotification
    {
        public PersonCreatedNotification(Person person)
        {
            Person = person;
        }

        public Person Person { get; set; }
    }
}
