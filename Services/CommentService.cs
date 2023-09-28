using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using WallAPI.DTO;
using WallAPI.Models;
using WallAPI.Repositories.Interface;
using WallAPI.Repositories.Interfaces;
using WallAPI.Services.Interfaces;

namespace WallAPI.Services
{
    public class CommentService : ICommentService
    {

        public readonly ICommentRepository _commentRepository;

        public readonly IPostRepository _postRepository;

        public readonly IUserRepository _userRepository;

        public IMapper _mapper;

        public CommentService (ICommentRepository commentRepository, IMapper mapper, IPostRepository postRepository, IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<bool> CreateComment (CommentDTO commentDTO)
        {
            if(commentDTO.Message.IsNullOrEmpty())
            {
                return false;
            }

            var tempPost = await _postRepository.GetOnePost(commentDTO.OriginPostId);
            if (tempPost == null)
            {
                return false;
            }
           
            
            var tempUser = await _userRepository.GetUser(commentDTO.CreatorUsername);
            if (tempUser == null)
            {
                return false;
            }

            var tempComment = new Comment();
            tempComment.CreatorUsername = commentDTO.CreatorUsername;
            tempComment.Message = commentDTO.Message;
            tempComment.OriginPostId = commentDTO.OriginPostId;
            tempComment.OriginPost = tempPost;

           await  _commentRepository.CreateComment(tempComment);
            return true;

        }

        public async Task<bool> DeleteOneComment(CommentDeleteDTO commentDeleteDto)
        {
            var tempComment = await _commentRepository.GetOneComment(commentDeleteDto.Id);

            if ( tempComment == null)
            {
                return false;
            }

            _commentRepository.DeleteOneComment(tempComment);
            return true;
        }

        public async Task<List<Comment>> GetAllCommentsOfOnePost(CommentGetAllDTO commentDTO)
        {
            var tempPost = _postRepository.GetOnePost(commentDTO.OriginPostId);
            if (tempPost == null)
            {
                return null;
            }
            return await _commentRepository.GetAllCommentsOfOnePost(commentDTO.OriginPostId);
           
        }

        public async Task<CommentUpdateDTO> UpdateComment(CommentUpdateDTO commentUpdateDto)
        {

            var existingComment = await _commentRepository.GetOneComment(commentUpdateDto.Id);

            if (existingComment == null
                || !existingComment.CreatorUsername.Equals(commentUpdateDto.CreatorUsername)
                || existingComment.OriginPostId != commentUpdateDto.OriginPostId)
            {
                return null;
            }

            

            existingComment.Message = commentUpdateDto.Message;

            _commentRepository.UpdateComment(existingComment);
            return _mapper.Map<CommentUpdateDTO>(existingComment);

        }


    }
}
