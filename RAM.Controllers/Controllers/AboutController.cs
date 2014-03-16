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
using ModestoPower.Core.Domain.Pages;

namespace RAM.Controllers.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IPagesRepository _pagesRepository;
        public AboutController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IPagesRepository pagesRepository,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, actionArguments)
        {
            _pagesRepository = pagesRepository;
        }


        public ActionResult Index()
        {
            var view = new HomeView();
            return View(view);

        }

        public ActionResult OurHistory()
        {
            var view = new HomeView();
            view.SelectedPage = _pagesRepository.GetByTitle("Our History");
            return View(view);

        }

        public ActionResult CommunityOutreach()
        {
            var view = new HomeView();
            view.SelectedPage = _pagesRepository.GetByTitle("Community Outreach");
            return View(view);

        }

        public ActionResult MembershipInfo()
        {
            var view = new HomeView();
            view.SelectedPage = _pagesRepository.GetByTitle("Membership Info");
            return View(view);

        }
    }
}
