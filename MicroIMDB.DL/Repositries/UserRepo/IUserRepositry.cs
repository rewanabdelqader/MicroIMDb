using MicroIMDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroIMDb.Infrastrcture.Repositries.UserRepo
{
    public interface IUserRepositry
    {
        Task<User> GetUserById(string userId);

    }
}
