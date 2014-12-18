using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BlogProject.Core.Entities;

namespace BlogProject.Models
{
    public class ChangePostViewModel : BaseModel
    {
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(2000)]
        public string Body { get; set; }

        public ChangePostViewModel()
        {
            
        }

        public ChangePostViewModel(Post post)
        {
            Id = post.Id;
            Title = post.Title;
            Body = post.Body;
        }
    }
}