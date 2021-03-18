using FluentValidationExample.Model;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(UserEntity user)
        {
            return NoContent();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("OK");
        }
    }
}