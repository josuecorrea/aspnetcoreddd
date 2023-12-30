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

namespace Project.Accounting.Service.Application.UseCases.Account.Create
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonRequest, BaseResult<CreatePersonResponse>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<CreatePersonHandler> _logger;
        private readonly ICacheService _cacheService;

        public CreatePersonHandler(IPersonRepository personRepository, IMediator mediator, ILogger<CreatePersonHandler> logger,
            ICacheService cacheService)
        {
            _personRepository = personRepository;
            _mediator = mediator;
            _logger = logger;
            _cacheService = cacheService;
        }

        public async Task<BaseResult<CreatePersonResponse>> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var person = request.Adapt<Person>();

                var personCreated = await CreatePerson(person);

                return new BaseResult<CreatePersonResponse>(person.MapToCreatePersonResponse(personCreated));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error ocurred while create new person!");

                return new BaseResult<CreatePersonResponse>(new Person().MapToCreatePersonResponse(false));
            }
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
                _logger.LogError(ex, "An error ocurred while create new person!");

                return false;
            }
        }
    }
}