using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.BLInterfaces.BLLInterfaces;
using BlogProject.BLInterfaces.Exceptions;
using BlogProject.Core.Entities;
using BlogProject.DALInterfaces;

namespace BlogProject.Services
{
    public class BlogService : BaseService, IBlogService
    {
        public BlogService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public Blog CreateBlog(string title, string body, DateTime createDate, Guid userId)
        {
            var blogRepository = RepositoryFactory.GetBlogRepository();
            var blog = new Blog {Body = body, Title = title, CreateDate = createDate, UserId = userId};
            blogRepository.Create(blog);

            try
            {
                UnitOfWork.PreSave();
            }
            catch (BlogServiceException ex)
            {
                throw new BlogServiceException(ex);
            }

            return blog;
        }

        public void UpdateBlog(Blog blog)
        {
            var blogRepository = RepositoryFactory.GetBlogRepository();

            try
            {
                blogRepository.Update(blog);
            }
            catch (BlogServiceException ex)
            {
                throw new BlogServiceException(ex);
            }
        }

        public void RemoveBlog(Blog blog)
        {
            var blogRepository = RepositoryFactory.GetBlogRepository();

            try
            {
                blogRepository.Remove(blog);
            }
            catch (BlogServiceException ex)
            {
                throw new BlogServiceException(ex);
            }
        }

        public Blog GetBlogById(int blogId)
        {
            var blogRepository = RepositoryFactory.GetBlogRepository();

            try
            {
                var blog = blogRepository.GetEntiyById(blogId);
                return blog;
            }
            catch (BlogServiceException ex)
            {
                throw new BlogServiceException(ex);
            }
        }

        public IQueryable<Blog> GetAllBlogs()
        {
            var blogRepository = RepositoryFactory.GetBlogRepository();

            try
            {
                var blog = blogRepository.All();
                return blog;
            }
            catch (BlogServiceException ex)
            {
                throw new BlogServiceException(ex);
            }
        }

        public void AddCommentToBlog(Comment comment, int blogId)
        {
            var blog = GetBlogById(blogId);
            blog.Comments.Add(comment);
        }

        public void RemoveCommentToBlog(Comment comment, int blogId)
        {
            var blog = GetBlogById(blogId);
            blog.Comments.Remove(comment);
        }
    }
}
