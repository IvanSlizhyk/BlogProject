using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Entities
{
    public class Point : BaseEntity<int>
    {
        public Comment Comment { get; set; }
        public int CommentId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserId { get; set; }
    }
}
