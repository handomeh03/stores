using Microsoft.AspNetCore.Identity;
using Stores.DataAccess;
using Stores.Models;

namespace Stores.BusinessLogic.Auth
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;
        private readonly PasswordHasher<UserModel> _passwordHasher = new();

        public AuthService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        
        public async Task<UserModel?> RegisterAsync(string name, string email, string password, string? phone)
        {
            
            var existingUser = await _userRepository.GetUserByEmailAsync(email);
            if (existingUser != null)
            {
                return null; 
            }

            var user = new UserModel
            {
                Name = name,
                Email = email,
                Phone = phone,
                Role = Role.CUSTOMER
            };

            
            user.Password = _passwordHasher.HashPassword(user, password);

            
            return await _userRepository.AddUserAsync(user);
        }

        
        public async Task<UserModel?> LoginAsync(string email, string password)
        {
            
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return null; 
            }

            
            var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (verificationResult == PasswordVerificationResult.Failed)
            {
                return null; 
            }

            return user; 
        }
    }
}