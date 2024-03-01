using MicroIMDb.Models;
using MicroIMDb.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroIMDb.Infrastrcture.Repositries.UserRepo
{
    public class UserRepositry : IUserRepositry
    {
        private readonly MicroIMDbDbContext _context;

        public UserRepositry(MicroIMDbDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(string userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}

