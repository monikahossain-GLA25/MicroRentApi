using MicroRentApi.Data;
using MicroRentApi.Models.Domain;
using MicroRentApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            var userDto =  new List<Models.DTO.UserDto>();

            foreach(var userDomain in user)
            {
                userDto.Add(new Models.DTO.UserDto()
                {
                    Id = userDomain.Id,
                    Code = userDomain.Code,
                    Name = userDomain.Name,
                    UserImageUrl = userDomain.UserImageUrl
                });
            }
            return Ok(userDto);
        }
        [HttpGet("{id:guid}")]
       
        public IActionResult GetById([FromRoute] Guid id)
        {
            // Get Domain Model
            var userDomain = microRentDbContext.Users
                .FirstOrDefault(x => x.Id == id);

            if (userDomain == null)
            {
                return NotFound();
            }


            // Map Domain Model to DTO
            var userDto = new UserDto
            {
                Id = userDomain.Id,
                Code = userDomain.Code,
                Name = userDomain.Name,
                UserImageUrl = userDomain.UserImageUrl
            };


            // Return DTO
            return Ok(userDto);
        }
    }
}
