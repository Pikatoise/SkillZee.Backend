using SkillZee.Domain.DTO.WorkerInfo;
using SkillZee.Domain.Entities;

namespace SkillZee.Application.MapperExtensions
{
    public static class WorkerInfoMapExtensions
    {
        public static WorkerInfoDto ToDto(this WorkerInfo workerInfo) => new WorkerInfoDto()
        {
            Id = workerInfo.Id,
            CreatedAt = workerInfo.CreatedAt,
            Description = workerInfo.Description,
            IsActive = workerInfo.IsActive,
            Areas = workerInfo.WorkerAreas.Select(x => x.ToDto()).ToList(),
            Skills = workerInfo.WorkerSkills.Select(x => x.ToDto()).ToList()
        };
    }
}
