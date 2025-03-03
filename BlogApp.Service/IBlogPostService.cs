using BlogApp.Core.Dtos;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service
{    public interface IBlogPostService
    {
        Task<IEnumerable<BlogPostDto>> GetBlogPostsAsync();
        Task<IEnumerable<BlogPostDto>> GetUserBlogPostsAsync(int userId);
        Task<BlogPostDto> CreateBlogPostAsync(BlogPostDto blogPost);
        Task<IEnumerable<BlogCategoryDto>> GetAllCategoriesAsync();

    }
}
