using Project.Accounting.Service.Domain.Contracts.Services;
using Project.Accounting.Service.Infra.Services;

namespace Project.Accounting.Service.Api.Config
{
    public static class ServicesDependecyInjection
    {
        public static IServiceCollection AddServicesDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<IBrokerService, BrokerService>();
            services.AddScoped<ICacheService, CacheService>();

            return services;
        }
    }
}
