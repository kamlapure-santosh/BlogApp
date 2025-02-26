using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace BlogApp.Core.Dtos
{
   public class BlogPostDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
