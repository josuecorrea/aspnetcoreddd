using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using PersonCreatedNotificationEvent;
using PersonCreateFailNotificationEvent;
using Project.Accounting.Service.Application.UseCases.Account.Create.Request;
using Project.Accounting.Service.Application.UseCases.Account.Create.Response;
using Project.Accounting.Service.Domain.Commom;
using Project.Accounting.Service.Domain.Contracts.Services;
using Project.Accounting.Service.Domain.Entities.PersonAgg;
using Project.Accounting.Service.Application.UseCases.Account.Create.Mapping;
using System;
using Microsoft.Extensions.Configuration;

namespace Project.Accounting.Service.Application.UseCases.Account.Create
{
    public class CreatePersonHandler : MediatrHandlerBase, IRequestHandler<CreatePersonRequest, BaseResult<CreatePersonResponse>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<CreatePersonHandler> _logger;
        private readonly ICacheService _cacheService;
        private readonly IConfiguration _configuration;

        public CreatePersonHandler(IPersonRepository personRepository, IMediator mediator,
            ILogger<CreatePersonHandler> logger,
            ICacheService cacheService, IConfiguration configuration)
        {
            _personRepository = personRepository;
            _mediator = mediator;
            _logger = logger;
            _cacheService = cacheService;
            _configuration = configuration;
        }

        public async Task<BaseResult<CreatePersonResponse>> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            var person = request.Adapt<Person>();

            var personCreated = await CreatePerson(person);

            return Result(person.MapToCreatePersonResponse(personCreated));
        }

        private async Task<bool> CreatePerson(Person person)
        {
            try
            {
                var personCreated = await _personRepository.Insert(person);

                if (personCreated)
                {
                    await _mediator.Publish(person.Adapt<PersonCreatedNotification>());
                    await _cacheService.SetValue(person.Id.ToString(), person, CacheTimeDefinition.OneYear());
                }
                else
                    await _mediator.Publish(new PersonCreateFailNotification(person));

                return personCreated;
            }
            catch (Exception ex)
            {
                var error = "An error ocurred while create new person!";
                AddError(error);
                _logger.LogError(ex, error);

                return false;
            }
        }
    }
}