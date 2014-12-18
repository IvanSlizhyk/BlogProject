using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.Core.Entities;

namespace BlogProject.BLInterfaces.BLLInterfaces
{
    public interface IPostService : IService
    {
        Post CreatePost(string title, string body, DateTime createDate, int userId);
        void UpdatePost(Post post);
        void RemovePost(Post post);
        Post GetPostById(int postId);
        IQueryable<Post> GetAllPosts();
        void AddCommentToPost(Comment comment, int postId);
        void RemoveCommentToPost(Comment comment, int postId);
    }
}
