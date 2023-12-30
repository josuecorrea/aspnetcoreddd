using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using PersonCreatedNotificationEvent;
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
        private readonly ILogger<CreatePersonHandler> _logger;

        public CreatePersonHandler(IPersonRepository personRepository, IMediator mediator, ILogger<CreatePersonHandler> logger)
        {
            _personRepository = personRepository;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<BaseResult<CreatePersonResponse>> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex,"An error ocurred while create new person!");

                return new BaseResult<CreatePersonResponse>(new CreatePersonResponse
                {
                    Id = Guid.Empty,
                    Created = false
                });
            }           
        }
    }
}