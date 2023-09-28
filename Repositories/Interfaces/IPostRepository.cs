using WallAPI.Models;

namespace WallAPI.Repositories.Interfaces
{
    public interface IPostRepository
    {
         Task CreatePost(Post post);
         Task DeleteOnePost(Post post);
         Task<List<Post>> GetAllPosts();
         Task<Post> GetOnePost(int id);
    }
}
