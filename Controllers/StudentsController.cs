using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroRentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames =
            {
                "Lira",
                "Doxygen",
                "Copilot",
                "GitHub"
            };

            return Ok(studentNames);
        }
    }
}
