using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogProject.EFData;
using BlogProject.Models;
using BlogProject.Services.Services;

namespace BlogProject.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var context = new BlogContext(Resources.ConnectionString);
            var unit = new UnitOfWork(context);

            var blogService = new BlogService(unit, unit);
            var postService = new PostService(unit, unit);

            var blogs = blogService.GetAllBlogs().ToList();
            var blogsCount = blogs.Count;

            var posts = postService.GetAllPosts().ToList();
            var postsCount = posts.Count;
            
            var blogViewModel = new BlogViewModel();
            var changePostViewModel = new ChangePostViewModel();
            var firstPageViewModel = new FirstPageViewModel();

            if (blogsCount!=0)
            {
                blogViewModel.Title = blogs[0].Title;
                blogViewModel.Body = blogs[0].Body;
            }
            else
            {
                blogViewModel.Title = "А что ты хочешь здесь прочитать?";
                blogViewModel.Body = "...";
            }

            if (postsCount!=0)
            {
                changePostViewModel.Title = posts[posts.Count - 1].Title;
                changePostViewModel.Body = posts[posts.Count - 1].Body;
            }
            else
            {
                changePostViewModel.Title = "No Title";
                changePostViewModel.Body = "No Body";
            }

            firstPageViewModel.BlogViewModel = blogViewModel;
            firstPageViewModel.ChangePostViewModel = changePostViewModel;

            return View(firstPageViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
