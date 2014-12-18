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
        IRepositoryGeneric<Post, int> GetPostRepository();
        IRepositoryGeneric<Comment, int> GetCommentRepository();
        IRepositoryGeneric<Point, int> GetPointRepository();
        IRepositoryGeneric<Blog, int> GetBlogRepository();
    }
}
