using Microsoft.EntityFrameworkCore;
using stores.data;
using Stores.Models;

namespace Stores.DataAccess
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

    
        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _context.users.ToListAsync();
        }


        public async Task<UserModel?> GetUserByIdAsync(int id)
        {
            return await _context.users.FindAsync(id);
        }

     
        public async Task<UserModel?> GetUserByEmailAsync(string email)
        {
            return await _context.users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        
        public async Task<UserModel> AddUserAsync(UserModel user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        
        public async Task UpdateUserAsync(UserModel user)
        {
            user.UpdatedAt = DateTime.UtcNow;
            _context.users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<string?> GetRoleNameByIdAsync(int RoleId)
        {
            var roleName = await _context.UserRoles
                .Where(r => r.Id == RoleId)
                .Select(r => r.RoleName)
                .FirstOrDefaultAsync();

            return roleName;
        }



        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user != null)
            {
                _context.users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}