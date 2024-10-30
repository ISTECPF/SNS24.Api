namespace SNS24.WebApi.Models
{
    public class BaseEntity
    {
        public Guid  Id { get; set; }
        public DateTime Created { get; } = DateTime.UtcNow;
        public DateTime Updated { get; set; }
    }
}
