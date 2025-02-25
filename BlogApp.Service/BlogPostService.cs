using BlogApp.Core.DatabaseContext;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Service
{
    public class BlogPostService : IBlogPostService
    {
        private readonly BlogDbContext _context;

        public BlogPostService(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogPost>> GetBlogPostsAsync()
        {
            return await _context.BlogPosts.Include(bp => bp.Comments).ToListAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetUserBlogPostsAsync(int userId)
        {
            return await _context.BlogPosts.Where(bp => bp.UserId == userId).Include(bp => bp.Comments).ToListAsync();
        }

        public async Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost)
        {
            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();
            return blogPost;
        }
    }
}
