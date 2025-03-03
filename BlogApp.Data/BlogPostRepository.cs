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
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogDbContext _context;

        public BlogPostRepository(BlogDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<BlogCategory>> GetAllCategoriesAsync()
        {
            var blogCategories = _context.BlogCategory.ToListAsync();
            return await blogCategories;
        }

        public async Task<IEnumerable<BlogPost>> GetBlogPostsAsync()
        {
            var blogPosts = _context.BlogPosts.Include(ct => ct.BlogCategory).Include(bp => bp.AppUser).Include(bp => bp.Comments).ToListAsync();
            return await blogPosts;
        }

        public async Task<IEnumerable<BlogPost>> GetUserBlogPostsAsync(int userId)
        {
            var blogPosts = _context.BlogPosts.Where(bp => bp.UserId == userId).Include(ct => ct.BlogCategory).Include(bp => bp.AppUser).Include(bp => bp.Comments).ToListAsync();
            return await blogPosts;
        }

        public async Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost)
        {
            try
            {
                var existingUser = _context.AppUsers.Local.FirstOrDefault(u => u.Id == blogPost.UserId);
                if (existingUser != null)
                {
                    blogPost.AppUser = existingUser;
                }
                else
                {
                    _context.Attach(blogPost.AppUser);
                }

                var existingCategory = _context.BlogCategory.Local.FirstOrDefault(u => u.Id == blogPost.BlogCategoryId);
                if (existingCategory != null)
                {
                    blogPost.BlogCategory = existingCategory;
                }
                else
                {
                    existingCategory = _context.BlogCategory.FirstOrDefault(u => u.Id == blogPost.BlogCategoryId); 
                    if (existingCategory != null)
                    {

                        blogPost.BlogCategory = existingCategory;
                    }
                    _context.Attach(blogPost.BlogCategory);
                }

                _context.BlogPosts.Add(blogPost);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return blogPost;
        }
    }
}
