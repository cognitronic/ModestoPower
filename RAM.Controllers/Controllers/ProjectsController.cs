using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Infrastructure.Authentication;
using RAM.Services.Interfaces;
using RAM.Controllers.ActionArguments;
using RAM.Controllers.ViewModels;
using RAM.Services.Messaging.Project;
using RAM.Core.Domain.Project;
using System.Web.Mvc;

namespace RAM.Controllers.Controllers
{
    public class ProjectsController : BaseController
    {
        public ProjectsController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, actionArguments)
        {
        }

        //
        // GET: /Portfolio/
        public ActionResult Index()
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-projects";
            return View(view);
        }

        public ActionResult ByTitle(string category, string title)
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-projects";
            return View(view);
        }
	}


}