using Microsoft.AspNetCore.Mvc;
using UIN.Library.Api.Auth;

namespace UIN.Library.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService = new JwtService();

        [HttpPost("login")]
        public IActionResult Login(string username, string role)
        {
            var token = _jwtService.GenerateToken(username, role);

            return Ok(new
            {
                token = token
            });
        }
    }
}