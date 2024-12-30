namespace SkillZee.Domain.Entities
{
    public class User: BaseEntity
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Nickname { get; set; } = null!;

        public bool IsWorker { get; set; } = false;

        public int SuccessOrders { get; set; }

        public string Avatar { get; set; } = null!;

        public DateTime LastOnline { get; set; }
    }
}
