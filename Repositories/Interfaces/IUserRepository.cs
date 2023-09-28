using WallAPI.Models;

namespace WallAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task AddUser(User user);
        public Task<User> GetUser(string username);
        public Task<User?> GetUserByEmail(string email);
    }
}
