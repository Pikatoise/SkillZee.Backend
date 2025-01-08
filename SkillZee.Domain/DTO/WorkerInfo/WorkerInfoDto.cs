using SkillZee.Domain.DTO.Area;
using SkillZee.Domain.DTO.Skill;

namespace SkillZee.Domain.DTO.WorkerInfo
{
    public record WorkerInfoDto(
        Guid Id,
        DateTime CreatedAt,
        bool IsActive,

        string Description,
        List<AreaDto> Areas,
        List<SkillDto> Skills);
}
