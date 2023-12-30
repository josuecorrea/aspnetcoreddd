using MediatR;
using Project.Accounting.Service.Application.UseCases.Account.Create.Response;
using Project.Accounting.Service.Domain.Commom;
using Project.Accounting.Service.Domain.Entities.PersonAgg;

namespace Project.Accounting.Service.Application.UseCases.Account.Create.Request
{
    public class CreatePersonRequest : IRequest<BaseResult<CreatePersonResponse>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public PersonType PersonType { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
