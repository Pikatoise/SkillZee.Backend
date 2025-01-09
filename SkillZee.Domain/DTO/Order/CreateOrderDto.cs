namespace SkillZee.Domain.DTO.Order
{
    public class CreateOrderDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public double Reward { get; set; }
        public Guid OrderSpeedId { get; set; }
        public Guid AreaId { get; set; }
        public Guid CustomerId { get; set; }
    }
}