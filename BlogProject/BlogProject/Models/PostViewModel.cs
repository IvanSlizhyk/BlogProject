using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BlogProject.Core.Entities;

namespace BlogProject.Models
{
    public class PostViewModel : BaseModel
    {
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(2000)]
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Comment> Comments { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<string> UsersName { get; set; }

        public PostViewModel()
        {
            
        }

        public PostViewModel(Post post, string userName)
        {
            Id = post.Id;
            Title = post.Title;
            Body = post.Body;
            CreateDate = post.CreateDate;
            UserId = post.UserId;
            Comments = post.Comments.ToList();
            UserName = userName;
            UsersName = new List<string>();
        }
    }
}