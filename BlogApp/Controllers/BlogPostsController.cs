﻿using BlogApp.Core.Dtos;
using BlogApp.Core.Entities;
using BlogApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;
        private readonly IUserService _userService;

        public BlogPostsController(IBlogPostService blogPostService, IUserService userService)
        {
            _blogPostService = blogPostService;
            _userService = userService;
        }

        [HttpGet("categories")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BlogCategoryDto>>> GetAllCategories()
        {
            var blogPosts = await _blogPostService.GetAllCategoriesAsync();
            return Ok(blogPosts);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BlogPostDto>>> GetBlogPosts()
        {
            var blogPosts = await _blogPostService.GetBlogPostsAsync();
            return Ok(blogPosts);
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BlogPostDto>>> GetUserBlogPosts(int userId)
        {
            var blogPosts = await _blogPostService.GetUserBlogPostsAsync(userId);
            return Ok(blogPosts);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BlogPostDto>> CreateBlogPost([FromForm] BlogPostDto blogPostDto, IFormFile? imageFile)
        {
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
                    blogPostDto.UserId = user.Id;
                    blogPostDto.AuthorName = user.Email;
                }
                else
                {
                    return BadRequest("User not found.");
                }
            }

            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);
                    blogPostDto.Image = memoryStream.ToArray();
                }
            }

            var createdBlogPost = await _blogPostService.CreateBlogPostAsync(blogPostDto);
            return CreatedAtAction(nameof(GetBlogPosts), new { id = createdBlogPost.Id }, createdBlogPost);
        }
    }
}
