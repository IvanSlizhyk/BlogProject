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
    public class PostService : BaseService, IPostService
    {
        public PostService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public Post CreatePost(string title, string body, DateTime createDate, int userId)
        {
            var postRepository = RepositoryFactory.GetPostRepository();
            var post = new Post { Body = body, Title = title, CreateDate = createDate, UserId = userId };
            postRepository.Create(post);

            try
            {
                UnitOfWork.PreSave();
            }
            catch (PostServiceException ex)
            {
                throw new PostServiceException(ex);
            }

            return post;
        }

        public void UpdatePost(Post post)
        {
            var postRepository = RepositoryFactory.GetPostRepository();

            try
            {
                postRepository.Update(post);
            }
            catch (PostServiceException ex)
            {
                throw new PostServiceException(ex);
            }
        }

        public void RemovePost(Post post)
        {
            var postRepository = RepositoryFactory.GetPostRepository();

            try
            {
                postRepository.Remove(post);
            }
            catch (PostServiceException ex)
            {
                throw new PostServiceException(ex);
            }
        }

        public Post GetPostById(int postId)
        {
            var postRepository = RepositoryFactory.GetPostRepository();

            try
            {
                var post = postRepository.GetEntiyById(postId);
                return post;
            }
            catch (PostServiceException ex)
            {
                throw new PostServiceException(ex);
            }
        }

        public IQueryable<Post> GetAllPosts()
        {
            var postRepository = RepositoryFactory.GetPostRepository();

            try
            {
                var post = postRepository.All();
                return post;
            }
            catch (PostServiceException ex)
            {
                throw new PostServiceException(ex);
            }
        }

        public void AddCommentToPost(Comment comment, int postId)
        {
            var post = GetPostById(postId);
            post.Comments.Add(comment);
        }

        public void RemoveCommentToPost(Comment comment, int postId)
        {
            var post = GetPostById(postId);
            post.Comments.Remove(comment);
        }
    }
}
