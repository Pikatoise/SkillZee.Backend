namespace SkillZee.Domain.Entities
{
    public class BalanceTransaction: BaseEntity
    {
        public double Amount { get; set; }

        public Guid UserId { get; set; }
        public required User User { get; set; }
    }
}
