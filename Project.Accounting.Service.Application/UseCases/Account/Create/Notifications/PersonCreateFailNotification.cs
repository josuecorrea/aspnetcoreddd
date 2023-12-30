using MediatR;
using Project.Accounting.Service.Domain.Entities.PersonAgg;

namespace PersonCreateFailNotificationEvent
{
    public class PersonCreateFailNotification : INotification
    {
        public PersonCreateFailNotification(Person person)
        {
            Person = person;
        }

        public Person Person { get; private set; }
    }
}
