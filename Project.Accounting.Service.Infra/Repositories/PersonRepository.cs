using Project.Accounting.Service.Domain.Entities.PersonAgg;
using System.Linq.Expressions;

namespace Project.Accounting.Service.Infra.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public Task<IEnumerable<Person>> GetFiltered(Expression<Func<bool, Person>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insert(Person person)
        {
            return true;
        }

        public Task<bool> Remove(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
