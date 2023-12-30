namespace Project.Accounting.Service.Domain.Commom
{
    public class EntityBase : IAggregateRoot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
    }
}
