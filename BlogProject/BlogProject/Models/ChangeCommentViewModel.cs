using System;
using System.ComponentModel.DataAnnotations;
using BlogProject.Core.Entities;

namespace BlogProject.Models
{
    public class ChangeCommentViewModel : BaseModel
    {
        public int PostId { get; set; }
        [MaxLength(2000)]
        public string Text { get; set; }

        public ChangeCommentViewModel()
        {
            
        }
    }
}