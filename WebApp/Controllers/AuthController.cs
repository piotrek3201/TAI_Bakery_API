using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Dtos;
using WebApp.Helpers;
using WebApp.Model;

namespace WebApp.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly JwtService jwtService;

        public AuthController(IUserRepository userRepository, JwtService jwtService)
        {
            this.userRepository = userRepository;
            this.jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = 0
            };

            return Created("Success", userRepository.Create(user));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = userRepository.GetByEmail(dto.Email);
            
            if (user == null)
                return BadRequest(new { message = "Invalid Credentials" });

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return BadRequest(new { message = "Invalid Credentials" });

            var jwt = jwtService.Generate(user.Id);

            /*
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });
            */

            return Ok(new
            {
                message = "success",
                token = jwt
            });
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var bearer = Request.Headers["Authorization"];

                var jwt = bearer.ToString().Substring("Bearer ".Length).Trim(); ;

                var token = jwtService.Verify(jwt);

                long userId = long.Parse(token.Issuer);

                var user = userRepository.GetById(userId);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            //Response.Cookies.Delete("jwt");

            return Ok(new { message = "success" });
        }
    }
}
