using Microsoft.EntityFrameworkCore;
using WallAPI.Models;
using WallAPI.Repositories.Interface;

namespace WallAPI.Repositories
{
    public class UserRepository : IUserRepository
    {

        public readonly WallDbContext _context;

        public UserRepository(WallDbContext context)
        
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<User> GetUser(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }


    }
}
