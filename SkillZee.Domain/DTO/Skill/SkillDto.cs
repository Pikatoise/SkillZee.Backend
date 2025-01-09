namespace SkillZee.Domain.DTO.Skill
{
    public class SkillDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public required string Title { get; set; }
    }
}
