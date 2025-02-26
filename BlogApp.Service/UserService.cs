using BlogApp.Core.Dtos;
using BlogApp.Core.Entities;
using BlogApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AppUserDto?> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return user != null ? new AppUserDto { Id = user.Id, Email = user.Email, Username = user.Username } : null;
        }

        public async Task<int> CreateUserAsync(AppUserDto userDto)
        {
            var user = new AppUser
            {
                Email = userDto.Email,
                Username = userDto.Username,
                Password = string.Empty
            };
            return await _userRepository.CreateUserAsync(user);
        }
    }
}
