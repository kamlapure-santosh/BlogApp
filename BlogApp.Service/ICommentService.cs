using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentsAsync(int postId);
        Task<Comment> CreateCommentAsync(Comment comment);
    }
}
