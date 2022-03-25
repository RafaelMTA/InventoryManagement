using IM.Application.Interfaces.Services;
using IM.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await _service.GetById(GetUserId());
            user.Password = ""; //Occult Password
            return Ok(user);
        }

        /// <summary>
        /// Checks password hash, and generates a Jwt Token and send it through a http-only cookie
        /// </summary>
        /// <param name="login">Login view model</param>
        /// <returns>Cookie with Jwt Token</returns>
        [HttpPost]
        [Route("SignIn")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                if (login.Password != login.ConfirmPassword) return BadRequest("Password and Confirm Password Mismatch!");
                var token = await _service.Login(login.Email, login.Password);
                //return Ok(token);
                Response.Cookies.Append("X-Access-Token", token, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.None });
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("SignUp")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                await _service.Insert(user);
                return Ok();
            }
            return BadRequest();
        }

        private Guid GetUserId()
        {
            var claims = HttpContext.User.Identities.FirstOrDefault().Claims.ToList();
            var userId = claims.Find(x => x.Type == "id").Value;
            Guid id = new Guid(userId);
            return id;
        }
    }
}
