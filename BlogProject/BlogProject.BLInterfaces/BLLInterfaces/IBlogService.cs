using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.Core.Entities;

namespace BlogProject.BLInterfaces.BLLInterfaces
{
    public interface IBlogService : IService
    {
        Blog CreateBlog(string body, string title, DateTime createDate, int userId);
        void UpdateBlog(Blog blog);
        void RemoveBlog(Blog blog);
        Blog GetBlogById(int blogId);
        IQueryable<Blog> GetAllBlogs();
    }
}
