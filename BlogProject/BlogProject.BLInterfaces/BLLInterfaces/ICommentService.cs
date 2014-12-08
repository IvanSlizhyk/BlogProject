using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.Core.Entities;

namespace BlogProject.BLInterfaces.BLLInterfaces
{
    public interface ICommentService : IService
    {
        Comment CreateComment(Guid userId, string text, DateTime createDate);
        void UpdateComment(Comment comment);
        void RemoveComment(Comment comment);
        Comment GetCommentById(int commentId);
        IQueryable<Comment> GetAllComments();
        void SetBlogOfComment(Blog blog, Comment comment);
        void AddPointToComment(Point point, int commentId);
        void RemovePointToCommnet(Point point, int commentId);
    }
}
