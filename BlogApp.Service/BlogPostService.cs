using AutoMapper;
using BlogApp.Core.Dtos;
using BlogApp.Core.Entities;
using BlogApp.Data;

namespace BlogApp.Service
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public BlogPostService(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BlogPostDto>> GetBlogPostsAsync()
        {
            var blogPosts = await _blogPostRepository.GetBlogPostsAsync();
            if (blogPosts != null)
            {
                return _mapper.Map<List<BlogPostDto>>(blogPosts);
            }
            return null;
        }

        public async Task<IEnumerable<BlogPostDto>> GetUserBlogPostsAsync(int userId)
        {

            var userBlog = await _blogPostRepository.GetUserBlogPostsAsync(userId);

            if (userBlog != null)
            {
                return _mapper.Map<List<BlogPostDto>>(userBlog);
            }
            return null;
        }

        public async Task<BlogPostDto> CreateBlogPostAsync(BlogPostDto blogPostDto)
        {
            var blogPost = _mapper.Map<BlogPost>(blogPostDto);
            var addedblogPost = await _blogPostRepository.CreateBlogPostAsync(blogPost);
            return _mapper.Map<BlogPostDto>(addedblogPost);
        }
    }
}
