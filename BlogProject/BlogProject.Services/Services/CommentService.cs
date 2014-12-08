using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.BLInterfaces.BLLInterfaces;
using BlogProject.BLInterfaces.Exceptions;
using BlogProject.Core.Entities;
using BlogProject.DALInterfaces;

namespace BlogProject.Services.Services
{
    public class CommentService : BaseService, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public Comment CreateComment(Guid userId, string text, DateTime createDate)
        {
            var commentRepository = RepositoryFactory.GetCommentRepository();
            var comment = new Comment {UserId = userId, Text = text, CreateDate = createDate};
            commentRepository.Create(comment);

            try
            {
                UnitOfWork.PreSave();
            }
            catch (CommentServiceException ex)
            {
                throw new CommentServiceException(ex);
            }

            return comment;
        }

        public void UpdateComment(Comment comment)
        {
            var commentRepository = RepositoryFactory.GetCommentRepository();

            try
            {
                commentRepository.Update(comment);
            }
            catch (CommentServiceException ex)
            {
                throw new CommentServiceException(ex);
            }
        }

        public void RemoveComment(Comment comment)
        {
            var commentRepository = RepositoryFactory.GetCommentRepository();

            try
            {
                commentRepository.Remove(comment);
            }
            catch (CommentServiceException ex)
            {
                throw new CommentServiceException(ex);
            }
        }

        public Comment GetCommentById(int commentId)
        {
            var commentRepository = RepositoryFactory.GetCommentRepository();

            try
            {
                var comment = commentRepository.GetEntiyById(commentId);
                return comment;
            }
            catch (CommentServiceException ex)
            {
                throw new CommentServiceException(ex);
            }
        }

        public IQueryable<Comment> GetAllComments()
        {
            var commentRepository = RepositoryFactory.GetCommentRepository();

            try
            {
                var comment = commentRepository.All();
                return comment;
            }
            catch (CommentServiceException ex)
            {
                throw new CommentServiceException(ex);
            }
        }

        public void SetBlogOfComment(Blog blog, Comment comment)
        {
            comment.Blog = blog;
            comment.BlogId = blog.Id;
        }

        public void AddPointToComment(Point point, int commentId)
        {
            var comment = GetCommentById(commentId);
            comment.Points.Add(point);
        }

        public void RemovePointToCommnet(Point point, int commentId)
        {
            var comment = GetCommentById(commentId);
            comment.Points.Remove(point);
        }
    }
}
