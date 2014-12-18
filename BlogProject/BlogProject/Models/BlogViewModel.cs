using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BlogProject.Core.Entities;

namespace BlogProject.Models
{
    public class BlogViewModel : BaseModel
    {
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(2000)]
        public string Body { get; set; }

        public BlogViewModel()
        {
            
        }

        public BlogViewModel(Blog blog)
        {
            Id = blog.Id;
            Title = blog.Title;
            Body = blog.Body;
        }
    }
}