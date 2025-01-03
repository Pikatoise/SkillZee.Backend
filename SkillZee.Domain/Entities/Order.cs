namespace SkillZee.Domain.Entities
{
    public class Order: BaseEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }

        public double Reward { get; set; }

        public Guid OrderSpeedId { get; set; }
        public required OrderSpeed OrderSpeed { get; set; }

        public Guid AreaId { get; set; }
        public required Area Area { get; set; }

        public Guid CustomerId { get; set; }
        public required User Customer { get; set; }

        public Guid? WorkerId { get; set; }
        public User? Worker { get; set; }

        public Guid? ResultId { get; set; }
        public OrderResult? Result { get; set; }
    }
}
