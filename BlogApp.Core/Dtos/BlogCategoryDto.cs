using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Dtos
{

    public class BlogCategoryDto
    {        
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
