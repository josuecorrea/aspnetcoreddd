using MediatR;
using Project.Accounting.Service.Application.UseCases.Account.Create;
using Project.Accounting.Service.Application.UseCases.Account.Create.Request;
using Project.Accounting.Service.Application.UseCases.Account.Create.Response;
using Project.Accounting.Service.Domain.Commom;

namespace Project.Accounting.Service.Api.Config
{
    public static class MediatrDependecyInjection
    {
        public static IServiceCollection AddMediatrDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreatePersonRequest, BaseResult<CreatePersonResponse>>, CreatePersonHandler>();

            return services;
        }
    }
}