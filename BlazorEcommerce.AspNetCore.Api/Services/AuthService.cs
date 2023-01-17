using System.Security.Cryptography;
using System.Text;

namespace BlazorEcommerce.AspNetCore.Api.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(User user, string password);

        Task<bool> UserExists(string email);
    }

    public sealed class AuthService : IAuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if (await UserExists(user.Email))
            {
                return new ()
                {
                    Success = false,
                    Message = "User already exists"
                };
            }

            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new () {  Data = user.Id, Message = "Registration Successful!"};
        }

        public async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(user =>
                user.Email.ToLower().Equals(email.ToLower()));
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();

            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
