using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Infrastructure.Authentication;
using RAM.Services.Interfaces;
using RAM.Controllers.ActionArguments;
using RAM.Controllers.ViewModels;
using System.Web.Mvc;
using RAM.Core.Domain.Banner;
using RAM.Core.Domain.Project;
using RAM.Core.Domain.Blog;
using ModestoPower.Core.Domain.Pages;

namespace RAM.Controllers.Controllers
{
    public class HomeController : BaseController
    {
        //private readonly IBannerService _bannerService;
        //private readonly IProjectService _projectService;
        private readonly IBlogRepository _blogRepository;
        private readonly IPagesRepository _pageRepository;
        public HomeController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IBlogRepository blogRepository,
            IPagesRepository pageRepository,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, actionArguments)
        {
            //_bannerService = bannerService;
            _pageRepository = pageRepository;
            _blogRepository = blogRepository;
        }


        public ActionResult Index()
        {
            HomeView view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-home";
            view.Posts = _blogRepository.GetAll();
            //Session.Add("_blog" + DateTime.Now.Ticks.ToString() + "_test", view.NavView.SelectedMenuItem);
            return View(view);

        }

        public ActionResult TopNavigation()
        {
            HomeView accountView = new HomeView();
            accountView.NavView.SelectedMenuItem = "nav-home";
            return PartialView("TopNavigation", accountView);

        }

        public ActionResult GetPage(Pages page)
        {
            var p = _pageRepository.GetByTitle(page.title);
            return Json(new
            {
                Message = "Page Grabbed",
                Status = "success",
                Page = p
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Banners()
        {
            HomeView accountView = new HomeView();
            accountView.NavView.SelectedMenuItem = "nav-home";
            return PartialView("_Banners",accountView);

        }

        public ActionResult Portfolio()
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-home";
            return PartialView("_Portfolio", view);

        }

        public ActionResult Features()
        {
            HomeView accountView = new HomeView();
            accountView.NavView.SelectedMenuItem = "nav-home";
            return PartialView("Features", accountView);

        }

        public ActionResult Footer()
        {
            HomeView accountView = new HomeView();
            accountView.NavView.SelectedMenuItem = "nav-home";
            return PartialView("Footer", accountView);

        }

    }
}
