using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using POS_Inventory_System.Models;
using POS_System.DTOs;

namespace POS_System.Controllers
{
    [Route("api/[controller]")]                 // API endpoint: /api/Role
    [ApiController]
    [Authorize(Roles = "Admin")]                // Only users with Admin role can access this controller
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // 1) Create a new Role
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                return BadRequest("Role name cannot be empty.");

            // Check if the role already exists
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (roleExists)
                return BadRequest($"{roleName} role already exists.");

            // Create the role
            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (result.Succeeded)
                return Ok($"Role '{roleName}' created successfully.");
            else
                return BadRequest($"Failed to create role '{roleName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }

        // Assign a Role to a User
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleModel model)
        {
            // Find the user by username
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
                return NotFound($"User '{model.UserName}' not found.");

            if (string.IsNullOrEmpty(model.RoleName))
                return BadRequest("Role name cannot be empty.");

            // Assign the role to the user
            var result = await _userManager.AddToRoleAsync(user, model.RoleName);
            if (result.Succeeded)
                return Ok($"Role '{model.RoleName}' assigned to user '{model.UserName}' successfully.");
            else
                return BadRequest($"Failed to assign role '{model.RoleName}' to user '{model.UserName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
}
