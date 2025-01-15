using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillZee.Domain.Result;
using SkillZee.Infrastructure.DAL.Repositories;

namespace SkillZee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController(/*IOrderService orderService,*/ UnitOfWork unitOfWork): ControllerBase
    {
        //readonly IOrderService _orderService = orderService;
        readonly UnitOfWork _unitOfWork = unitOfWork;

        //[HttpPost("create")]
        //public async Task<BaseResult<OrderDto>> CreateOrder([FromBody] CreateOrderDto createDto)
        //{
        //    var result = await _orderService.CreateOrder(createDto);

        //    return result;
        //}

        [HttpGet]
        public async Task<BaseResult<int>> GetOrderSpeedsCount()
        {
            var orderSpeedsCount = await _unitOfWork.OrderSpeeds.GetAll().CountAsync();

            return new BaseResult<int>(orderSpeedsCount);
        }
    }
}
