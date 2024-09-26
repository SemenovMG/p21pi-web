using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using p21pi_web.Models.Requests;
using p21pi_web.Services;

namespace p21pi_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _sevice;

        public AuthController(
            IAuthService sevice
        )
        {
            _sevice = sevice;
        }

        [HttpPost("/login")]
        public IActionResult Login(string login, string password)
        {
            return Ok(_sevice.Login(login, password));
        }

        [HttpPost("/register")]
        public IActionResult Register(RegisterRequest request)
        {
            return Ok(_sevice.Register(
                request.Email,
                request.Login,
                request.Password));
        }
    }
}
