using SkillZee.Domain.DTO.WorkerInfo;

namespace SkillZee.Domain.DTO.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public required string Nickname { get; set; }
        public required string AvatarUri { get; set; }
        public bool IsWorker { get; set; }
        public int SuccessOrders { get; set; }
        public DateTime LastOnline { get; set; }
        public WorkerInfoDto? WorkerInfo { get; set; }
    }
}
