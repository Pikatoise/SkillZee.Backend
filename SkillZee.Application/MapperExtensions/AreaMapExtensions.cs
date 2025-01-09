using SkillZee.Domain.DTO.Area;
using SkillZee.Domain.Entities;

namespace SkillZee.Application.MapperExtensions
{
    public static class AreaMapExtensions
    {
        public static AreaDto ToDto(this Area area) => new AreaDto()
        {
            Id = area.Id,
            Title = area.Title,
            IsActive = area.IsActive,
            CreatedAt = area.CreatedAt
        };
    }
}
