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
            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Content)) // Map Content property
                .ReverseMap();
        }
    }
}
