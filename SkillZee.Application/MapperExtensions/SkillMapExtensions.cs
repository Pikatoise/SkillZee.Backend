using SkillZee.Domain.DTO.Skill;
using SkillZee.Domain.Entities;

namespace SkillZee.Application.MapperExtensions
{
    public static class SkillMapExtensions
    {
        public static SkillDto ToDto(this Skill skill) => new SkillDto()
        {
            Id = skill.Id,
            CreatedAt = skill.CreatedAt,
            IsActive = skill.IsActive,
            Title = skill.Title
        };
    }
}
