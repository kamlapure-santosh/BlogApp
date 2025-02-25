using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service
{    public interface IBlogPostService
    {
        Task<IEnumerable<BlogPost>> GetBlogPostsAsync();
        Task<IEnumerable<BlogPost>> GetUserBlogPostsAsync(int userId);
        Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost);
    }
}
