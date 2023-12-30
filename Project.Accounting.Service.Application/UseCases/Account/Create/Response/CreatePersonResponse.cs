namespace Project.Accounting.Service.Application.UseCases.Account.Create.Response
{
    public record CreatePersonResponse
    {
        public Guid Id { get; set; }
        public bool Created { get; set; }
    }
}