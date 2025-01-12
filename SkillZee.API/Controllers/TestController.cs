using Microsoft.AspNetCore.Mvc;
using SkillZee.Domain.DTO.Order;
using SkillZee.Domain.Interfaces.Services;
using SkillZee.Domain.Result;

namespace SkillZee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController(IOrderService orderService): ControllerBase
    {
        readonly IOrderService _orderService = orderService;

        [HttpPost("create")]
        public async Task<BaseResult<OrderDto>> CreateOrder([FromBody] CreateOrderDto createDto)
        {
            var result = await _orderService.CreateOrder(createDto);

            return result;
        }
    }
}
