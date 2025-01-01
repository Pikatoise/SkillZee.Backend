namespace SkillZee.Domain.Entities
{
    public class OrderResult: BaseEntity
    {
        public double TotalReward { get; set; }
        public TimeSpan WorkingTime { get; set; }

        public byte? WorkerScore { get; set; }
        public byte? CustomerScore { get; set; }

        public Guid? TipId { get; set; }
        public Tip? Tip { get; set; }

        public Guid OrderId { get; set; }
        public required Order Order { get; set; }
    }
}
