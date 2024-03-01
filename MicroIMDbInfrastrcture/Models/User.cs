using Microsoft.AspNetCore.Identity;

namespace MicroIMDb.Models
{
    public class User: IdentityUser<int>
    {
        public bool IsAdmin { get; set; } = false;
    }
}
