namespace SkillZee.Domain.Entities
{
    public class Tip: BaseEntity
    {
        public double Amount { get; set; }

        public Guid ResultId { get; set; }
        public OrderResult Result { get; set; } = null!;
    }
}
