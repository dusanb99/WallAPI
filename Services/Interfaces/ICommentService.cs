using WallAPI.DTO;
using WallAPI.Models;
using WallAPI.Repositories.Interfaces;

namespace WallAPI.Services.Interfaces
{
    public interface ICommentService
    {
        Task<bool> CreateComment(CommentDTO commentDTO);
        Task<bool> DeleteOneComment(CommentDeleteDTO commentDeleteDto);
        Task<List<Comment>> GetAllCommentsOfOnePost(CommentGetAllDTO commentDTO);
    }
}
