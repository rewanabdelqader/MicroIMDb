using MicroIMDb.Application.Dtos;
using MicroIMDb.Application.Services.Movie;
using MicroIMDb.Application.Services.User;
using MicroIMDb.Infrastrcture.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroIMDb.API.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("admin/add")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> AddAdminUser([FromBody] AddUserDto user)
        {
            user.Role = "Admin"; 
            var addedUser = await _userService.AddUser(user);
            if (addedUser == null)
            {
                return StatusCode(500, "Failed to add the admin user.");
            }

            return CreatedAtAction("AddAdminUser", addedUser); 
        }

    }
}
