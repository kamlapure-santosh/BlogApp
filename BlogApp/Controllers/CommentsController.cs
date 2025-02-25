using BlogApp.Core.Dtos;
using BlogApp.Core.Entities;
using BlogApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("api/blogposts/{postId}/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetComments(int postId)
        {
            var comments = await _commentService.GetCommentsAsync(postId);
            return Ok(comments);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CommentDto>> CreateComment(int postId, CommentDto commentDto)
        {
            commentDto.BlogPostId = postId; 
            var userIdClaim = User.FindFirst("user_id") ?? User.FindFirst("sub");
            if (userIdClaim != null)
            {
                //commentDto.UserId = int.Parse(userIdClaim.Value);
                commentDto.UserId = 1;
            }
            else
            {
                return BadRequest("User ID claim not found.");
            }
            var createdComment = await _commentService.CreateCommentAsync(commentDto);
            return CreatedAtAction(nameof(GetComments), new { postId = postId }, createdComment);
        }
    }
}
