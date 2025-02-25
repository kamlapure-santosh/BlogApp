using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace BlogApp.Core.Dtos
{
   public class CommentDto
    {

        [JsonIgnore]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Content { get; set; }

        public int BlogPostId { get; set; }

        public int UserId { get; set; }
    }
}
