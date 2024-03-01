using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MicroIMDb.Models
{
    public class User: IdentityUser<int>
    {
        public bool IsAdmin { get; set; } = false;
    }
}
