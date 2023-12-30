using Mapster;
using MediatR;
using Project.Accounting.Service.Application.UseCases.Account.Create.Notifications;
using Project.Accounting.Service.Application.UseCases.Account.Create.Request;
using Project.Accounting.Service.Application.UseCases.Account.Create.Response;
using Project.Accounting.Service.Domain.Commom;
using Project.Accounting.Service.Domain.Entities.PersonAgg;


namespace Project.Accounting.Service.Application.UseCases.Account.Create
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonRequest, BaseResult<CreatePersonResponse>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMediator _mediator;

        public CreatePersonHandler(IPersonRepository personRepository, IMediator mediator)
        {
            _personRepository = personRepository;
            _mediator = mediator;
        }

        public async Task<BaseResult<CreatePersonResponse>> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            var person = request.Adapt<Person>();

            var personCreated = await _personRepository.Insert(person);

            if (personCreated)
            {
                await _mediator.Publish(person.Adapt<PersonCreatedNotification>());
            }

            return new BaseResult<CreatePersonResponse>(new CreatePersonResponse
            {
                Id = person.Id,
                Created = true                
            });
        }
    }
}
