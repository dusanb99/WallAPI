using WallAPI.Models;

namespace WallAPI.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task CreateComment(Comment comment);
        Task DeleteOneComment(Comment comment);
        Task<List<Comment>> GetAllCommentsOfOnePost(int postId);
        Task<Comment> GetOneComment(int id);
        Task UpdateComment(Comment comment);
    }
}
