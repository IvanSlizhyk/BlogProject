using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.Models
{
    public class FirstPageViewModel : BaseModel
    {
        public BlogViewModel BlogViewModel { get; set; }
        public ChangePostViewModel ChangePostViewModel { get; set; }

        public FirstPageViewModel()
        {
            
        }
    }
}