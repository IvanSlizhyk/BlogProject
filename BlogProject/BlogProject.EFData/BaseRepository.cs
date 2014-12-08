using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.EFData
{
    public class BaseRepository
    {
        protected BlogContext Context { get; set; }

        public BaseRepository(BlogContext context)
        {
            Context = context;
        }
    }
}
