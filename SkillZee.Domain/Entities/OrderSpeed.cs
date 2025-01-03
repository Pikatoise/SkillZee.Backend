namespace SkillZee.Domain.Entities
{
    public class OrderSpeed: BaseEntity
    {
        public required string Title { get; set; }

        public double RewardMultiplier { get; set; }

        public List<Order> Orders { get; set; } = [];
    }
}
