using BlogApp.Core.Dtos;
using BlogApp.Core.Entities;
using BlogApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("api/blogposts/{postId}/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public CommentsController(ICommentService commentService, IUserService userService)
        {
            _commentService = commentService;
            _userService = userService;
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
            if (string.IsNullOrEmpty(commentDto.Comment))
            {
                return BadRequest("Comment content cannot be null or empty.");
            }

            commentDto.BlogPostId = postId;
            var firebaseClaim = User.FindFirst("firebase");
            if (firebaseClaim != null)
            {
                var firebaseData = JsonDocument.Parse(firebaseClaim.Value);
                if (firebaseData.RootElement.TryGetProperty("identities", out var identities) &&
                    identities.TryGetProperty("email", out var emails) &&
                    emails[0].GetString() is string email)
                {
                    // get user from the database
                    var user = await _userService.GetUserByEmailAsync(email);
                    commentDto.UserId = user.Id;
                }
                else
                {
                    return BadRequest("User not found.");
                }
            }

            var createdComment = await _commentService.CreateCommentAsync(commentDto);
            return CreatedAtAction(nameof(GetComments), new { postId = postId }, createdComment);
        }
    }
}
