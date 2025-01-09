using SkillZee.Domain.DTO.Area;
using SkillZee.Domain.DTO.Skill;

namespace SkillZee.Domain.DTO.WorkerInfo
{
    public class WorkerInfoDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public required string Description { get; set; }
        public required List<AreaDto> Areas { get; set; }
        public required List<SkillDto> Skills { get; set; }
    }
}
