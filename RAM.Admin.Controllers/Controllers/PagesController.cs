using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Admin.Controllers.ViewModels;
using RAM.Core.Domain.User;
using RAM.Admin.Controllers.ActionArguments;
using RAM.Infrastructure.Authentication;
using RAM.Services.Interfaces;
using System.Web.Mvc;
using System.Web;
using System.IO;
using System.Configuration;
using ModestoPower.Core.Domain.Pages;

namespace RAM.Admin.Controllers.Controllers
{
    public class PagesController : BaseUserAccountController
    {
        private readonly IPagesRepository _pagesRepository;
        public PagesController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IPagesRepository pagesRepository,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {
            _pagesRepository = pagesRepository;
        }

        public ActionResult Index()
        {
            HomeView view = new HomeView();
            view.WebPages = _pagesRepository.GetAll();
            view.NavView.SelectedMenuItem = "nav-banners";
            return View(view);

        }
    }
}
