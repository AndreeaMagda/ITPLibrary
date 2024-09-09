using AutoMapper;
using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Data.Entities;
using ITPLibrary.Api.Data.Repositories;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ITPLibrary.Api.Core.Services
{
    public interface IUserService
    {
        Task RegisterUserAsync(UserRegistrationDto userRegistrationDto);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task RegisterUserAsync(UserRegistrationDto userRegistrationDto)
        {
            if (userRegistrationDto.Password != userRegistrationDto.ConfirmPassword)
            {
                throw new ArgumentException("Passwords do not match");
            }

            var existingUser = await _userRepository.GetUserByEmailAsync(userRegistrationDto.Email);
            if (existingUser != null)
            {
                throw new Exception("User with this email already exists.");
            }

            var user = _mapper.Map<User>(userRegistrationDto);
            user.Username = userRegistrationDto.Email; // Assuming Username is derived from Email
            user.PasswordHash = HashPassword(userRegistrationDto.Password);

            await _userRepository.AddUserAsync(user);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
