namespace SkillZee.Domain.DTO.Area
{
    public class AreaDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public required string Title { get; set; }
    }
}
