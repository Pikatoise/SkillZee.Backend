namespace SkillZee.Domain.Entities
{
    public class OrderResponse: BaseEntity
    {
        public Guid WorkerId { get; set; }
        public User Worker { get; set; } = null!;

        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
    }
}
