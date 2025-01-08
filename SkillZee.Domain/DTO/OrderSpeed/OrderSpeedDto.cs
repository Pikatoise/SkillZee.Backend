namespace SkillZee.Domain.DTO.OrderSpeed
{
    public record OrderSpeedDto(
        Guid Id,
        DateTime CreatedAt,
        bool IsActive,

        string Title,
        double RewardMultiplier);
}
