namespace SkillZee.Domain.Filters
{
    public class OrderFilter
    {
        public string? Title { get; set; }

        public double? RewardMin { get; set; }

        public double? RewardMax { get; set; }

        public Guid? OrderSpeedId { get; set; }

        public Guid? AreaId { get; set; }
    }
}
