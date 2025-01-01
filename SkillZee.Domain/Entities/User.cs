namespace SkillZee.Domain.Entities
{
    public class User: BaseEntity
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Nickname { get; set; }

        public double Balance { get; set; }

        public required string AvatarUri { get; set; }

        public bool IsWorker { get; set; } = false;

        public int SuccessOrders { get; set; }

        public DateTime LastOnline { get; set; }
    }
}
