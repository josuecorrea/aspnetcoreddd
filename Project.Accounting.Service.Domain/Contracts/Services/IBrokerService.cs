namespace Project.Accounting.Service.Domain.Contracts.Services
{
    public interface IBrokerService
    {
        Task Publish<T>(T mesage, string queue);
    }
}
