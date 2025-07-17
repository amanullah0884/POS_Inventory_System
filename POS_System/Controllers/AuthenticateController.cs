using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using POS_Inventory_System.Models; // ApplicationUser
using POS_System.DTOs;
using POS_System.Security; // TokenManager
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenManager _tokenManager;

        public AuthenticateController(UserManager<ApplicationUser> userManager, ITokenManager tokenManager)
        {
            _userManager = userManager;
            _tokenManager = tokenManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                return BadRequest("User already exists!");

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return StatusCode(500, new { message = errors });
            }

            return Created("", "User created successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
                return Unauthorized("Invalid username or password");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!isPasswordValid)
                return Unauthorized("Invalid username or password");

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = _tokenManager.GenerateAccessToken(authClaims);

            return Ok(new
            {
                token = token,
                expiration = DateTime.Now.AddMinutes(30)
            });
        }
    }
}




//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using POS_Inventory_System.Models;

//namespace POS_System.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthenticateController : ControllerBase
//    {
//        private UserManager<ApplicationUser> _userManager;
//        public AuthenticateController(UserManager<ApplicationUser> userManager)
//        {
//            this._userManager = userManager;

//        }
//        [HttpPost]
//        [Authorize]
//        public async Task<IActionResult> Register(ApplicationUser user)
//        {
//            var insertUser = new ApplicationUser
//            {
//                UserName = user.UserName,
//                Email = user.Email,
//                PhoneNumber = user.PhoneNumber

//            };
//            var result = await _userManager.CreateAsync(insertUser, user.PasswordHash);

//            if (result.Succeeded)
//            {
//                return Created("", user);
//            }
//            else if (result.Errors.Count() > 0)
//            {
//                string msg = string.Join(",", result.Errors.Select(e => $"{e.Code} - {e.Description}"));
//                return StatusCode(StatusCodes.Status500InternalServerError, new { message = msg });
//            }
//            else
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unknow error!" });
//            }

//        }
//    }
//}
