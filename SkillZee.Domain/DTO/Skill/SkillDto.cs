namespace SkillZee.Domain.DTO.Skill
{
    public record SkillDto(
        Guid Id,
        DateTime CreatedAt,
        bool IsActive,

        string Title);
}
