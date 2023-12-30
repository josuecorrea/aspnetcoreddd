using MediatR;
using System.Reflection;

namespace Project.Accounting.Service.Api.Config
{
    public static class MediatrConfig
    {
        public static IServiceCollection AddMediatrConfig(this IServiceCollection services)
        {
            //const string applicationAssemblyName = "Project.Accounting.Service.Application";
            //var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            //AssemblyScanner
            //    .FindValidatorsInAssembly(assembly)
            //    .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CommandPipelineValidationBehavior<,>));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            return services;
        }
    }
}
