using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using WallAPI.DTO;
using WallAPI.Models;
using WallAPI.Repositories.Interface;
using WallAPI.Repositories.Interfaces;
using WallAPI.Services.Interfaces;

namespace WallAPI.Services
{
    public class PostService : IPostService
    {

        public readonly IPostRepository _postRepository;
        public readonly IUserRepository _userRepository;
        public IMapper _mapper;

        public PostService (IPostRepository postRepository, IMapper mapper, IUserRepository userRepository )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<bool> CreatePost (PostDTO postDTO)
        {
            if(postDTO.CreatorUsername.IsNullOrEmpty() || 
                postDTO.Message.IsNullOrEmpty() ) 
            {
                return false;
            }

            var tempUser = await _userRepository.GetUser(postDTO.CreatorUsername);
            if( tempUser == null )
            {
                return false;
            }

            var tempPost = _mapper.Map<Post>(postDTO);
            tempPost.User = tempUser;
            tempPost.CreatedAt = DateTime.Now;
            tempPost.UserId = tempUser.Id; 
            tempPost.CreatorUsername = tempUser.Username;

            await _postRepository.CreatePost(tempPost);
            
            return true;
        }

        public async Task<IEnumerable<PostOutDTO>> GetAllPosts()
        {
            var posts = await _postRepository.GetAllPosts();

            return _mapper.Map<IEnumerable<PostOutDTO>>(posts);
        }

        public async Task<bool> DeleteOnePost(PostDeleteDTO postDeleteDTO)
        {
            var tempPost = await _postRepository.GetOnePost(postDeleteDTO.Id);

            if (tempPost == null)
            {
                return false;
            }

            var tempUser =await _userRepository.GetUser(postDeleteDTO.Username);
            if ( tempUser == null || !tempPost.CreatorUsername.Equals(tempUser.Username))
            {
                return false;
            }

            await _postRepository.DeleteOnePost(tempPost);

            return true;
        }


    }
}
