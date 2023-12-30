using System.Linq.Expressions;

namespace Project.Accounting.Service.Domain.Entities.PersonAgg
{
    public interface IPersonRepository
    {
        Task<bool> Insert(Person person);
        Task<bool> Update(Person person);
        Task<IEnumerable<Person>> GetFiltered(Expression<Func<bool, Person>> predicate);
        Task<bool> Remove(Person person);
    }
}