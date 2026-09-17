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
       
        public async Task<IActionResult> GetAll()
        {
            var users = await microRentDbContext.Users.ToListAsync();

            var userDto = new List<UserDto>();

            foreach (var userDomain in users)
            {
                userDto.Add(new UserDto
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

       
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var userDomain = await microRentDbContext.Users
                .FirstOrDefaultAsync(x => x.Id == id);

            if (userDomain == null)
            {
                return NotFound();
            }

            var userDto = new UserDto
            {
                Id = userDomain.Id,
                Code = userDomain.Code,
                Name = userDomain.Name,
                UserImageUrl = userDomain.UserImageUrl
            };

            return Ok(userDto);
        }

        [HttpPost]

        public async Task<IActionResult> Create(
    [FromBody] AddUserRequestDto addUserRequestDto)
        {
            var userDomainModel = new User
            {
                Code = addUserRequestDto.Code,
                Name = addUserRequestDto.Name,
                UserImageUrl = addUserRequestDto.UserImageUrl
            };

            await microRentDbContext.Users.AddAsync(userDomainModel);

            await microRentDbContext.SaveChangesAsync();

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
  
        public async Task<IActionResult> Update(
    [FromRoute] Guid id,
    [FromBody] UpdateUserRequestDto updateUserRequestDto)
        {
            var userDomainModel = await microRentDbContext.Users
                .FirstOrDefaultAsync(x => x.Id == id);

            if (userDomainModel == null)
            {
                return NotFound();
            }

            userDomainModel.Code = updateUserRequestDto.Code;
            userDomainModel.Name = updateUserRequestDto.Name;
            userDomainModel.UserImageUrl = updateUserRequestDto.UserImageUrl;

            await microRentDbContext.SaveChangesAsync();

            var userDto = new UserDto
            {
                Id = userDomainModel.Id,
                Code = userDomainModel.Code,
                Name = userDomainModel.Name,
                UserImageUrl = userDomainModel.UserImageUrl
            };

            return Ok(userDto);
        }
        [HttpDelete("{id:guid}")]

       
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var userDomainModel = await microRentDbContext.Users
                .FirstOrDefaultAsync(x => x.Id == id);

            if (userDomainModel == null)
            {
                return NotFound();
            }

            microRentDbContext.Users.Remove(userDomainModel);

            await microRentDbContext.SaveChangesAsync();

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
