using Project.Accounting.Service.Domain.Entities.PersonAgg;
using Project.Accounting.Service.Infra.Repositories;

namespace Project.Accounting.Service.Api.Config
{
    public static class RepositoriesDependecyInjection
    {
        public static IServiceCollection AddRepositoriesDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }
    }
}
