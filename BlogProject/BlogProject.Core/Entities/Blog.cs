using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Entities
{
    public class Blog : BaseEntity<int>
    {
        public string Body { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
    }
}
