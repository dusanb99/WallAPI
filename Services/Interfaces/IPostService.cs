using WallAPI.DTO;

namespace WallAPI.Services.Interfaces
{
    public interface IPostService
    {
        public Task<bool> CreatePost(PostDTO postDTO);
        public Task<bool> DeleteOnePost(PostDeleteDTO postDeleteDTO);
        public Task<IEnumerable<PostOutDTO>> GetAllPosts();
        Task<PostOutDTO> UpdatePost(PostUpdateDTO postUpdateDto);
    }
}
