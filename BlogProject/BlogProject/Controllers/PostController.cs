using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BlogProject.Core.Entities;
using BlogProject.EFData;
using BlogProject.Models;
using BlogProject.Services.Services;
using WebMatrix.WebData;

namespace BlogProject.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public ActionResult Id()
        {
            var context = new BlogContext(Resources.ConnectionString);
            var unit = new UnitOfWork(context);
            var blogService = new BlogService(unit, unit);

            var userId = WebSecurity.GetUserId(HttpContext.User.Identity.Name);
            blogService.CreateBlog("No body", "No title", DateTime.Now, userId);
            unit.Commit();
            context.Dispose();
            
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var context = new BlogContext(Resources.ConnectionString);
            var unit = new UnitOfWork(context);

            var postService = new PostService(unit, unit);
            var posts = postService.GetAllPosts().ToList();

            var allPostViewModel = new AllPostViewModel(posts);
            return View(allPostViewModel);
        }

        [HttpGet]
        public ActionResult Article(int postId)
        {
            var contex = new BlogContext(Resources.ConnectionString);
            var unit = new UnitOfWork(contex);
            var postService = new PostService(unit, unit);

            var post = postService.GetPostById(postId);
            var postViewModel = new PostViewModel(post);

            return View(postViewModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreatePost()
        {
            var roles = (SimpleRoleProvider)Roles.Provider;

            if (roles.IsUserInRole(HttpContext.User.Identity.Name, "Admin"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Post");
            }
        }

        [HttpPost]
        public ActionResult CreatePost(ChangePostViewModel changePostViewModel)
        {
            var context = new BlogContext(Resources.ConnectionString);
            var unit = new UnitOfWork(context);

            var postService = new PostService(unit, unit);
            int userId = WebSecurity.GetUserId(HttpContext.User.Identity.Name);
            postService.CreatePost(changePostViewModel.Title, changePostViewModel.Body, DateTime.Now, userId);
            
            unit.Commit();
            context.Dispose();

            return RedirectToAction("Index", "Post");
        }

        [HttpGet]
        public ActionResult EditPost(int postPageId)
        {
            var roles = (SimpleRoleProvider)Roles.Provider;

            if (roles.IsUserInRole(HttpContext.User.Identity.Name,"Admin"))
            {
                var context = new BlogContext(Resources.ConnectionString);
                var unit = new UnitOfWork(context);

                var postService = new PostService(unit, unit);
                var post = postService.GetPostById(postPageId);

                context.Dispose();

                var changePostViewModel = new ChangePostViewModel(post);

                return View(changePostViewModel);
            }
            else
            {
                return RedirectToAction("Article", "Post", new {postId = postPageId});
            }
        }

        [HttpPost]
        public ActionResult EditPost(ChangePostViewModel changePostViewModel)
        {
            var context = new BlogContext(Resources.ConnectionString);
            var unit = new UnitOfWork(context);
            var postService = new PostService(unit, unit);
            var post = postService.GetPostById(changePostViewModel.Id);
            post.Title = changePostViewModel.Title;
            post.Body = changePostViewModel.Body;
            postService.UpdatePost(post);
            unit.Commit();
            context.Dispose();
            
            return RedirectToAction("Index", "Post");
        }

        [HttpGet]
        public ActionResult DeletePost(int postViewModelId)
        {
            var roles = (SimpleRoleProvider)Roles.Provider;

            if (roles.IsUserInRole(HttpContext.User.Identity.Name, "Admin"))
            {
                var context = new BlogContext(Resources.ConnectionString);
                var unit = new UnitOfWork(context);
                var postService = new PostService(unit, unit);

                var post = postService.GetPostById(postViewModelId);
                postService.RemovePost(post);

                unit.Commit();
                context.Dispose();

                return RedirectToAction("Index", "Post");
            }
            else
            {
                return RedirectToAction("Article", "Post", new {postId = postViewModelId});
            }
        }

        [HttpGet]
        public ActionResult CreateComment(int postId)
        {
            var commentViewModel = new ChangeCommentViewModel() {PostId = postId};
            
            return View(commentViewModel);
        }

        [HttpPost]
        public ActionResult CreateComment(ChangeCommentViewModel changeCommentViewModel)
        {
            var context = new BlogContext(Resources.ConnectionString);
            
            var unit = new UnitOfWork(context);
            var commentService = new CommentService(unit, unit);
            var postService = new PostService(unit, unit);

            var post = postService.GetPostById(changeCommentViewModel.PostId);
            int userId = WebSecurity.GetUserId(HttpContext.User.Identity.Name);
            commentService.CreateComment(userId, changeCommentViewModel.Text, DateTime.Now, post);

            unit.Commit();
            context.Dispose();

            return RedirectToAction("Article", "Post", new {postId = post.Id});
        }

        [HttpGet]
        public ActionResult DeleteComment(int postViewModelId)
        {
            var roles = (SimpleRoleProvider)Roles.Provider;
            int currentUserId = WebSecurity.GetUserId(HttpContext.User.Identity.Name);

            var context = new BlogContext(Resources.ConnectionString);
            var unit = new UnitOfWork(context);
            var commentService = new CommentService(unit, unit);
            var comment = commentService.GetCommentById(postViewModelId);
            var postPageId = comment.PostId;

            if (roles.IsUserInRole(HttpContext.User.Identity.Name, "Admin")|| comment.UserId==currentUserId)
            {
                commentService.RemoveComment(comment);

                unit.Commit();
                context.Dispose();
            }

            context.Dispose();

            return RedirectToAction("Article", "Post", new { postId = postPageId });
        }

    }
}
