using JwtToken.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();

        [HttpPost("register")]
        public ActionResult<User>Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.UserName = request.UserName;
            user.Passwordhash = passwordHash;

            return Ok(user);
        }


        [HttpPost("login")]
        public ActionResult<User>Login(UserDto request)
        {
            if(user.UserName !=request.UserName)
            {
                return BadRequest("User not found");

            }
            if(!BCrypt.Net.BCrypt.Verify(request.Password,user.Passwordhash))
            {
                return BadRequest("Wrong password");
            }
            return Ok(user);
        }
    }
}
