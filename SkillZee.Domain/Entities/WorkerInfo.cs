namespace SkillZee.Domain.Entities
{
    public class WorkerInfo: BaseEntity
    {
        public required string Description { get; set; } = String.Empty;

        public IEnumerable<Area> WorkerAreas { get; set; } = [];
        public IEnumerable<Skill> WorkerSkills { get; set; } = [];

        public required User User { get; set; }
        public Guid WorkerId { get; set; }
    }
}
