using Project.Accounting.Service.Application.UseCases.Account.Create.Response;
using Project.Accounting.Service.Domain.Entities.PersonAgg;

namespace Project.Accounting.Service.Application.UseCases.Account.Create.Mapping
{
    public static class PersonToCreatePersonResponseMap
    {
        public static CreatePersonResponse MapToCreatePersonResponse(this Person person, bool created)
        {
            return new CreatePersonResponse
            {
                Id = created ? person.Id : Guid.NewGuid(),
                Created = created
            };
        }
    }
}
