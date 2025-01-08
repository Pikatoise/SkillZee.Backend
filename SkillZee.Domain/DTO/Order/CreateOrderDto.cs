namespace SkillZee.Domain.DTO.Order
{
    public record CreateOrderDto(
        string Title,
        string Description,
        double Reward,
        Guid OrderSpeedId,
        Guid AreaId,
        Guid CustomerId);
}
