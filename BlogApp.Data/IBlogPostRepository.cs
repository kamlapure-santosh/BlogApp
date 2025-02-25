using BlogApp.Core.Entities;

namespace BlogApp.Data
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetBlogPostsAsync();
        Task<IEnumerable<BlogPost>> GetUserBlogPostsAsync(int userId);
        Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost);
    }
}
