using SkillZee.Domain.Enum;

namespace SkillZee.Domain
{
    public class SortParams
    {
        public string? OrderBy { get; set; }

        public SortDirection? SortDirection { get; set; }
    }
}
