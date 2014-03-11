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


namespace RAM.Controllers.Controllers
{
    public class ServicesController : BaseController
    {
        public ServicesController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, actionArguments)
        {
        }

        //
        // GET: /Services/
        public ActionResult Index()
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-services";
            return View(view);
        }

        public ActionResult Industrial()
        {
            HomeView view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-services";
            return View(view);
        }

        public ActionResult Commercial()
        {
            HomeView view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-services";
            return View(view);
        }

        public ActionResult Residential()
        {
            HomeView view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-services";
            return View(view);
        }

        public ActionResult BuildingMaintenance()
        {
            HomeView view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-services";
            return View(view);
        }
	}
}