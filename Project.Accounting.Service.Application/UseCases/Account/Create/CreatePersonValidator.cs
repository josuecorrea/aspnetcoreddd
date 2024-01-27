using FluentValidation;
using Project.Accounting.Service.Application.UseCases.Account.Create.Request;

namespace Project.Accounting.Service.Application.UseCases.Account.Create
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonRequest> 
    {
        public CreatePersonValidator()
        {
            RuleFor(x => x.Name).Length(0, 10);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.BirthDate).NotNull();
        }
    }
}