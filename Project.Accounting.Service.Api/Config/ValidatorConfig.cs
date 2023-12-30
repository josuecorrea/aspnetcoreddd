using FluentValidation;
using Project.Accounting.Service.Application.UseCases.Account.Create;
using Project.Accounting.Service.Application.UseCases.Account.Create.Request;

namespace Project.Accounting.Service.Api.Config
{
    public static class ValidatorConfig
    {
        public static IServiceCollection AddValidatorConfig(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreatePersonRequest>, CreatePersonValidator>();

            return services;
        }
    }
}
