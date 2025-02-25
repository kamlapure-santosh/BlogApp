using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace BlogApp.Core.Dtos
{
    public class AppUserDto
    {

        [JsonIgnore]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<BlogPostDto> BlogPosts { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
