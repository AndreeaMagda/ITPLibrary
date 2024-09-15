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
        Task<User> LoginUserAsync(LoginUserDto loginUserDto);
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

        public async Task<User> LoginUserAsync(LoginUserDto loginUserDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginUserDto.Email);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            if (user.PasswordHash != HashPassword(loginUserDto.Password))
            {
                throw new Exception("Invalid password.");
            }

            return user;
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

        private bool VerifyPassword(string password, string passwordHash)
        {
            var hash = HashPassword(password);
            return hash == passwordHash;
        }
    }
}
