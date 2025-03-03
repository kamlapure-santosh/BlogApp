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
            CreateMap<BlogPost, BlogPostDto>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.AppUser.Username))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.AppUser.Id))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.BlogCategoryId))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.BlogCategory.CategoryName))
                .ReverseMap();

            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.CommentedBy, opt => opt.MapFrom(src => src.AppUser.Username))
                .ReverseMap();

            CreateMap<BlogCategory, BlogCategoryDto>()
               .ReverseMap();
        }
    }
}
