using AutoMapper;
using BlogApp.Core.Dtos;
using BlogApp.Core.Entities;
using System.Net;

namespace BlogApp.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
        }
    }
}
