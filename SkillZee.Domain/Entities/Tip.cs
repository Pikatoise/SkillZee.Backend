namespace SkillZee.Domain.Entities
{
    public class Tip: BaseEntity
    {
        public double Amount { get; set; }

        public Guid OrderId { get; set; }
        public required Order Order { get; set; }
    }
}
