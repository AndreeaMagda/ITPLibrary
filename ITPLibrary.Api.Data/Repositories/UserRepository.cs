using Dapper;
using ITPLibrary.Api.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;


namespace ITPLibrary.Api.Data.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
    }
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task AddUserAsync(User user)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var query = "INSERT INTO Users (Username, Email, PasswordHash) VALUES (@Username, @Email, @PasswordHash)";
                await connection.ExecuteAsync(query, user);
            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var query = "SELECT * FROM Users WHERE Email = @Email";
                return await connection.QuerySingleOrDefaultAsync<User>(query, new { Email = email });
            }
        }
    }
}
