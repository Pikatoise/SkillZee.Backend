namespace SkillZee.Domain.Entities
{
    public class Area: BaseEntity
    {
        public required string Title { get; set; }

        public List<WorkerInfo> WorkerInfos { get; set; } = [];

        public List<Order> Orders { get; set; } = [];
    }
}
