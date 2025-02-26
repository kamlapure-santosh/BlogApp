using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data
{
    public interface IUserRepository
    {
        Task<AppUser?> GetUserByEmailAsync(string email);
        Task<int> CreateUserAsync(AppUser user);
    }
}
