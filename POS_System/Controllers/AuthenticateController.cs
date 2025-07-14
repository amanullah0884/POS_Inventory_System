using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using POS_Inventory_System.Models;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public AuthenticateController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;

        }
        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUser user)
        {
            var insertUser = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber

            };
            var result = await _userManager.CreateAsync(insertUser, user.PasswordHash);

            if (result.Succeeded)
            {
                return Created("", user);
            }
            else if (result.Errors.Count() > 0)
            {
                string msg = string.Join(",", result.Errors.Select(e => $"{e.Code} - {e.Description}"));
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = msg });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Unknow error!" });
            }
        }
    }
}
