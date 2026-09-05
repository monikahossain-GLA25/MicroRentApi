using MicroRentApi.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroRentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = new List<User>()
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Code = "U001",
                    Name = "Monika Hossain",
                    UserImageUrl = "https://example.com/images/monika.jpg"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Code = "U003",
                    Name = "Hossain Monika",
                    UserImageUrl = "https://example.com/images/hossain.jpg"
                },
            };
            return Ok(users);
        }
    }
}
