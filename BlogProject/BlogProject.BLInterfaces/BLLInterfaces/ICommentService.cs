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
        Comment CreateComment(int userId, string text, DateTime createDate, Post post);
        void UpdateComment(Comment comment);
        void RemoveComment(Comment comment);
        Comment GetCommentById(int commentId);
        IQueryable<Comment> GetAllComments();
        void SetPostOfComment(Post post, Comment comment);
        void AddPointToComment(Point point, int commentId);
        void RemovePointToCommnet(Point point, int commentId);
    }
}
