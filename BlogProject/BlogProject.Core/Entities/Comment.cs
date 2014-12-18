using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Entities
{
    public class Comment : BaseEntity<int>
    {
        public int UserId { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ICollection<Point> Points { get; set; }

        public Comment()
        {
            Points = new Collection<Point>();
        }
    }
}
