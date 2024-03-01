using MicroIMDb.Application.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroIMDb.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<Models.User> _userManager;

        public UserService(UserManager<Models.User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Models.User> AddUser(AddUserDto userDto)
        {
            var user = new Models.User
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                // If user creation fails, handle the error
                // For simplicity, returning null here, but you can handle errors as needed
                return null;
            }
        }
    }
}
