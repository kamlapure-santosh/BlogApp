using BlogApp.Core.DatabaseContext;
using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service
{
    public class CommentService : ICommentService
    {
        private readonly BlogDbContext _context;

        public CommentService(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync(int postId)
        {
            return await _context.Comments.Where(c => c.BlogPostId == postId).ToListAsync();
        }

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}
