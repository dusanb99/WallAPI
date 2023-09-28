using WallAPI.Models;

namespace WallAPI.Repositories.Interface
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User> GetUser(string username);
        Task<User?> GetUserByEmail(string email);
    }
}
