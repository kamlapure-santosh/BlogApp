using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Dtos
{
   public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int BlogPostId { get; set; }
        public BlogPostDto BlogPost { get; set; }

        public int UserId { get; set; }
        public AppUserDto AppUser { get; set; }
    }
}
