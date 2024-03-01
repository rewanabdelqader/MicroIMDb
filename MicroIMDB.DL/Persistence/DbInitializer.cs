using MicroIMDb.Infrastrcture.Models;
using MicroIMDb.Models;
using Microsoft.AspNetCore.Identity;


namespace MicroIMDb.Infrastrcture.Persistence
{
    public class DbInitializer
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                    
             }


            // Check if the User table is empty
            if (_userManager.FindByEmailAsync("myuser@example.com").Result== null)
            {
                // Create a default admin user
                var user = new User
                {
                    UserName = "myuser",
                    Email = "myuser@example.com",
                    EmailConfirmed = true,
                };

                var result = await _userManager.CreateAsync(user, "Pa$$w0rd");
                if (result.Succeeded)
                {
                   await  _userManager.AddToRoleAsync(user, UserRoles.Admin);
                    Console.WriteLine("Default admin user created successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to create default admin user:");
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"Error: {error.Description}");
                    }
                }
            }

        }
    }
}
