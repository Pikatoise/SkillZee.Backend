namespace SkillZee.Domain.Entities
{
    public class OrderResponse: BaseEntity
    {
        public Guid WorkerId { get; set; }
        public required User Worker { get; set; }

        public Guid OrderId { get; set; }
        public required Order Order { get; set; }
    }
}
