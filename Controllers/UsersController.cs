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

            var userDto = new List<Models.DTO.UserDto>();

            foreach (var userDomain in user)
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

        [HttpPost]
        public IActionResult Create([FromBody] AddUserRequestDto addUserRequestDto)
        {
            var userDomainModel = new Models.Domain.User
            {
                Code = addUserRequestDto.Code,
                Name = addUserRequestDto.Name,
                UserImageUrl = addUserRequestDto.UserImageUrl
            };

            microRentDbContext.Users.Add(userDomainModel);
            microRentDbContext.SaveChanges();

            var userDto = new UserDto
            {
                Id = userDomainModel.Id,
                Code = userDomainModel.Code,
                Name = userDomainModel.Name,
                UserImageUrl = userDomainModel.UserImageUrl
            };
            return CreatedAtAction(
        nameof(GetById),
        new { id = userDto.Id },
        userDto);
        }
        [HttpPut("{id:guid}")]
        public IActionResult Update(
     [FromRoute] Guid id,
     [FromBody] UpdateUserRequestDto updateUserRequestDto)
        {
            var userDominModel = microRentDbContext.Users.FirstOrDefault(x => x.Id == id);

            if(userDominModel == null)
            {
                return NotFound();
            }
          
            userDominModel.Code = updateUserRequestDto.Code;
            userDominModel.Name = updateUserRequestDto.Name;
            userDominModel.UserImageUrl = updateUserRequestDto.UserImageUrl;

            microRentDbContext.SaveChanges();


            var userDto = new UserDto
            {
                Id = userDominModel.Id,
                Code = userDominModel.Code,
                Name = userDominModel.Name,
                UserImageUrl = userDominModel.UserImageUrl
            };
            return Ok(userDto);
        }
        [HttpDelete("{id:guid}")]
        
        public IActionResult Delete([FromRoute] Guid id)
        {
            var userDomainModel = microRentDbContext.Users.FirstOrDefault(x => x.Id == id);
            if (userDomainModel == null)
            {
                return NotFound();
        
            }
            microRentDbContext.Users.Remove(userDomainModel);
            microRentDbContext.SaveChanges();

            var userDto = new UserDto
            {
                Id = userDomainModel.Id,
                Code = userDomainModel.Code,
                Name = userDomainModel.Name,
                UserImageUrl = userDomainModel.UserImageUrl
            }; 
            return Ok(userDto);
        }
    }
}
