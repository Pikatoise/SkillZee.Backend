namespace SkillZee.Domain.Entities
{
    public class Skill: BaseEntity
    {
        public required string Title { get; set; }

        public List<WorkerInfo> WorkerInfos { get; set; } = [];
    }
}
