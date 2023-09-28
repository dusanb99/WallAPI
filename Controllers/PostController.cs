using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cmp;
using WallAPI.DTO;
using WallAPI.Services.Interfaces;

namespace WallAPI.Controllers
{

    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostService _postService;

        public PostController(IPostService service)
        {
            _postService = service;
        }

        [HttpGet("get_all_posts")]
        public async Task<ActionResult<IEnumerable<PostOutDTO>>> GetAllPosts()
        {
            var result = await _postService.GetAllPosts();
            if (result == null) 
            {
                result = new List<PostOutDTO>();
            }
            return Ok(result);
        }

        [HttpPost("create_post")]
        public async Task<ActionResult> CreatePost(PostDTO post)
        {
            var result = await _postService.CreatePost(post);

            return result == false ? BadRequest() : Ok("Post created.");
        }

        [HttpDelete("delete_post")]
        public async Task<ActionResult> DeleteOnePost(PostDeleteDTO postDeleteDTO)
        {
            var result = await _postService.DeleteOnePost(postDeleteDTO);

            return result == false ? BadRequest() : Ok("Post deleted.");
        }


        [HttpPut ("update_post")]

        public async Task<ActionResult> UpdatePost (PostUpdateDTO postUpdateDto)
        {
            var result = await _postService.UpdatePost(postUpdateDto);

            if (result == null)
            {
                return BadRequest(); 
            }
            return Ok(result);
        }
    }
}
