using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Infrastructure.Authentication;
using RAM.Services.Interfaces;
using RAM.Controllers.ActionArguments;
using RAM.Controllers.ViewModels;
using RAM.Services.Messaging.Blog;
using RAM.Core.Domain.Blog;
using System.Web.Mvc;

namespace RAM.Controllers.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogRepository _blogRepository;
        public BlogController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IBlogRepository blogRepository,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, actionArguments)
        {
            _blogRepository = blogRepository;
        }


        public ActionResult Index()
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-blog";
            view.Posts = _blogRepository.GetAll();
            return View(view);

        }

        public ActionResult GetList()
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-blog";
            return PartialView("BlogList", view);
        }

        public ActionResult LatestPosts()
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-blog";
            return PartialView("LatestPosts", view);
        }

        public ActionResult ByTitle(string category, string title)
        {

            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-blog";
            view.SelectedPost = _blogRepository.GetByTitle(title.Replace("-", " "));
            return View("Post", view);

        }

        public ActionResult ByCategory(string category)
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-blog";
            view.Posts = _blogRepository.GetByCategory(category.Replace("-", " "));
            return View("Index", view);

        }

        public ActionResult Sidebar(string category)
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-blog";
            view.Posts = _blogRepository.GetAll();
            return PartialView("_Sidebar", view);

        }
    }
}
