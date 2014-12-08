using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.Core.Entities;

namespace BlogProject.DALInterfaces
{
    public interface IRepositoryFactory
    {
        IRepositoryGeneric<Blog, int> GetBlogRepository();
        IRepositoryGeneric<Comment, int> GetCommentRepository();
        IRepositoryGeneric<Point, int> GetPointRepository();
    }
}
