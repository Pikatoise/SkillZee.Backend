namespace SkillZee.Domain.DTO.Area
{
    public record AreaDto(
        Guid Id,
        DateTime CreatedAt,
        bool IsActive,

        string Title);
}
