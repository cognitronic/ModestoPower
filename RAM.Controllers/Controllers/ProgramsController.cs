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
    public class ProgramsController : BaseController
    {
        private readonly IBlogService _blogService;
        public ProgramsController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IBlogService blogService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, actionArguments)
        {

            _blogService = blogService;
        }


        public ActionResult Index()
        {
            var view = new HomeView();
            return View(view);

        }
    }
}
