using Project.Accounting.Service.Domain.Commom;

namespace Project.Accounting.Service.Domain.Entities.PersonAgg
{
    public class Person : EntityBase
    {
        public Person(string name, string email, DateTime birthDate, PersonType type)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Type = type;
        }

        public Person()
        {
            
        }

        public string Name { get; private set; } 
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public PersonType Type { get; private set; } 
    }
}
