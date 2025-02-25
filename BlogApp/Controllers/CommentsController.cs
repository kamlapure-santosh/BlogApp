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
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetComments(int postId)
        {
            var comments = await _commentService.GetCommentsAsync(postId);
            return Ok(comments);
        }

        [HttpPost]
       // [Authorize]
        public async Task<ActionResult<CommentDto>> CreateComment(int postId, CommentDto commentDto)
        {
            commentDto.BlogPostId = postId;
         //   commentDto.UserId = int.Parse(User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value);
            var createdComment = await _commentService.CreateCommentAsync(commentDto);
            return CreatedAtAction(nameof(GetComments), new { postId = postId }, createdComment);
        }
    }
}
