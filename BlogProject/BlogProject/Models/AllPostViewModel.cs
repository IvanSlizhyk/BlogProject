using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogProject.Core.Entities;
using Microsoft.Ajax.Utilities;

namespace BlogProject.Models
{
    public class AllPostViewModel : BaseModel
    {
        public List<Post> Posts { get; set; }

        public AllPostViewModel()
        {
            
        }

        public AllPostViewModel(List<Post> posts )
        {
            Posts = posts;
        }
    }
}