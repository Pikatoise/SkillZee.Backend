namespace SkillZee.Domain.Entities
{
    public class Order: BaseEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }

        public double Reward { get; set; }

        public Guid OrderSpeedId { get; set; }
        public OrderSpeed OrderSpeed { get; set; } = null!;

        public Guid AreaId { get; set; }
        public Area Area { get; set; } = null!;

        public Guid CustomerId { get; set; }
        public User Customer { get; set; } = null!;

        public Guid? WorkerId { get; set; }
        public User? Worker { get; set; }

        public Guid? ResultId { get; set; }
        public OrderResult? Result { get; set; }

        public List<OrderResponse> Responses { get; set; } = [];
    }
}
