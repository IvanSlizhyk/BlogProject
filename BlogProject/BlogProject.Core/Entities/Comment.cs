using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Entities
{
    public class Comment : BaseEntity<int>
    {
        public Guid UserId { get; set; }
        public Blog Blog { get; set; }
        public int BlogId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<Point> Points { get; set; }
    }
}
