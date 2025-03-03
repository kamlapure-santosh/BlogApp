using BlogApp.Core.DatabaseContext;
using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDbContext _dbContext;

        public CommentRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Comment> CreateCommentAsync(Comment comment)
        {

            var existingUser = _dbContext.AppUsers.Local.FirstOrDefault(u => u.Id == comment.UserId);
            if (existingUser != null)
            {
                comment.AppUser = existingUser;
            }
            else
            {
                _dbContext.Attach(comment.AppUser);
            }
            _dbContext.Comments.Add(comment);
            await _dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync(int postId)
        {
            var obj = await _dbContext.Comments.Where(c => c.BlogPostId == postId).Include(user => user.AppUser).ToListAsync();
            return obj;

        }
    }
}
