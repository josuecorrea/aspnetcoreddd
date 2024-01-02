using Project.Accounting.Service.Domain.Commom;

namespace Project.Accounting.Service.Api.Config
{
    public static class SettingsConfig
    {
        public static IServiceCollection AddSettingsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionsConfigurations>(configuration.GetSection("ConnectionStrings"));

            return services;
        }
    }
}
