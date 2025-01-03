using Microsoft.AspNetCore.Mvc;
using SkillZee.Infrastructure.DAL.Repositories;

namespace SkillZee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController(UnitOfWork unit): ControllerBase
    {
        UnitOfWork _unit = unit;

        [HttpGet]
        public ActionResult Get()
        {
            var usersCount = _unit.Users.GetAll().Count();

            return Ok($"{usersCount}");
        }
    }
}
