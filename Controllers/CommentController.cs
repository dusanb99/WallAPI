using Microsoft.AspNetCore.Mvc;
using WallAPI.DTO;
using WallAPI.Models;
using WallAPI.Services;
using WallAPI.Services.Interfaces;

namespace WallAPI.Controllers
{

    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentService _commentService;

        public CommentController(ICommentService service)
        {
            _commentService = service;
        }

        [HttpPost("create_comment")]
        public async Task<ActionResult> CreateComment(CommentDTO commentDto)
        {
            var result = await _commentService.CreateComment(commentDto);

            return result == false ? BadRequest() : Ok("Comment created.");
        }

        [HttpDelete("delete_comment")]
        public async Task<ActionResult> DeleteComment(CommentDeleteDTO commentDeleteDto)
        {
            var result = await _commentService.DeleteOneComment(commentDeleteDto);

            return result == false ? BadRequest() : Ok("Comment deleted.");
        }

        [HttpGet("post_comments")]
        public async Task<ActionResult<List<Comment>>> GetAllCommentsOfOnePost([FromQuery]CommentGetAllDTO commentDto)
        {
            var result = await _commentService.GetAllCommentsOfOnePost(commentDto);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut("update_comment")]

        public async Task<ActionResult> UpdateComment(CommentUpdateDTO commentUpdateDto)
        {
            var result = await _commentService.UpdateComment(commentUpdateDto);

            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }





    }
}
