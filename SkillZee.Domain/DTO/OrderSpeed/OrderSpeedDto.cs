namespace SkillZee.Domain.DTO.OrderSpeed
{
    public class OrderSpeedDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public required string Title { get; set; }
        public double RewardMultiplier { get; set; }
    }
}
