using AutoMapper;
using BlogApp.Core.DatabaseContext;
using BlogApp.Core.Dtos;
using BlogApp.Core.Entities;
using BlogApp.Data;
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
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsAsync(int postId)
        {
            var comments = await _commentRepository.GetCommentsAsync(postId);

            if (comments != null)
            {
                return _mapper.Map<List<CommentDto>>(comments);
            }
            return null;
        }

        public async Task<CommentDto> CreateCommentAsync(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            var addedComment = await _commentRepository.CreateCommentAsync(comment);
            return _mapper.Map<CommentDto>(addedComment);
        }
    }
}
