using BlogApp.Core.Entities;

namespace BlogApp.Data
{
    public interface ICommentRepository
    {       
        Task<IEnumerable<Comment>> GetCommentsAsync(int postId);
        Task<Comment> CreateCommentAsync(Comment comment);
    }
}
