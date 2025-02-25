using BlogApp.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service
{
    public interface IUserService
    {
        Task<AppUserDto?> GetUserByEmailAsync(string email);
        Task CreateUserAsync(AppUserDto user);
    }
}
