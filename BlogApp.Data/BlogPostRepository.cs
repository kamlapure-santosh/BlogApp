using BlogApp.Core.DatabaseContext;
using BlogApp.Core.Dtos;
using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data
{
    public class BlogPostRepository: IBlogPostRepository
    {
        private readonly BlogDbContext _context;

        public BlogPostRepository(BlogDbContext context)
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
