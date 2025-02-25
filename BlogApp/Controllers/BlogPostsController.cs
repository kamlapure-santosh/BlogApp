using BlogApp.Core.Dtos;
using BlogApp.Core.Entities;
using BlogApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostsController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPostDto>>> GetBlogPosts()
        {
            var blogPosts = await _blogPostService.GetBlogPostsAsync();
            return Ok(blogPosts);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<BlogPostDto>>> GetUserBlogPosts(int userId)
        {
            var blogPosts = await _blogPostService.GetUserBlogPostsAsync(userId);
            return Ok(blogPosts);
        }

        [HttpPost]
      //  [Authorize]
        public async Task<ActionResult<BlogPostDto>> CreateBlogPost(BlogPostDto blogPostDto)
        {
            //    blogPostDto.UserId = int.Parse(User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value);
            var createdBlogPost = await _blogPostService.CreateBlogPostAsync(blogPostDto);
            return CreatedAtAction(nameof(GetBlogPosts), new { id = createdBlogPost.Id }, createdBlogPost);
        }
    }
}
