namespace SkillZee.Domain.Entities
{
    public class WorkerInfo: BaseEntity
    {
        public required string Description { get; set; } = String.Empty;

        public List<Area> WorkerAreas { get; set; } = [];
        public List<Skill> WorkerSkills { get; set; } = [];

        public required User Worker { get; set; }
        public Guid WorkerId { get; set; }
    }
}
