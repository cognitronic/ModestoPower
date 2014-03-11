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
    public class AboutController : BaseController
    {
        
        public AboutController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, actionArguments)
        {
            
        }


        public ActionResult Index()
        {
            var view = new HomeView();
            return View(view);

        }

        public ActionResult OurHistory()
        {
            var view = new HomeView();
            return View(view);

        }

        public ActionResult CommunityOutreach()
        {
            var view = new HomeView();
            return View(view);

        }

        public ActionResult MembershipInfo()
        {
            var view = new HomeView();
            return View(view);

        }
    }
}
