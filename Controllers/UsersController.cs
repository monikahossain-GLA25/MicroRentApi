using MicroRentApi.Data;
using MicroRentApi.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroRentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MicroRentDbContext microRentDbContext;

        public UsersController(MicroRentDbContext microRentDbContext) {
            this.microRentDbContext = microRentDbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var user = microRentDbContext.Users.ToList();
            return Ok(user);
        }
    }
}
