using Mapster;
using Project.Accounting.Service.Application.UseCases.Account.Create.Request;
using Project.Accounting.Service.Domain.Entities.PersonAgg;

namespace Project.Accounting.Service.Api.Config
{
    public static class RegisterMapsterConfiguration
    {
        public static void AddRegisterMapsterConfiguration(this IServiceCollection services)
        {
            //TypeAdapterConfig<CreatePersonRequest, Person>()
            //    .NewConfig()
            //    .Map(dest => dest.FullName, src => $"{src.Title} {src.FirstName} {src.LastName}");
        }
    }
}
