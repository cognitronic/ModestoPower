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
using ModestoPower.Core.Domain.Programs;

namespace RAM.Admin.Controllers.Controllers
{
    public class ProgramController : BaseUserAccountController
    {
        private readonly IProgramService _programService;
        public ProgramController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IProgramService programService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {
            _programService = programService;
        }

        public ActionResult Index()
        {
            HomeView view = new HomeView();
            view.Programs = _programService.GetAll();
            view.NavView.SelectedMenuItem = "nav-programs";
            return View(view);

        }

        public ActionResult ProgramsList()
        {
            HomeView view = new HomeView();
            view.Programs = _programService.GetAll();
            view.NavView.SelectedMenuItem = "nav-programs";
            return PartialView("_ProgramsList", view);
        }

        public ActionResult Save(Program program) 
        {
            HomeView view = new HomeView();
            program.imagepaths.Add("/images/BG/customer_px.png");
            program.imagepaths.Add("/images/BG/IMG_0851.png");
            program.imagepaths.Add("/images/BG/testimonials_px.png");
            _programService.Save(program);
            return Json(new {
                Message = "Program Saved!",
                ProgramRef = program
        });
        }
    }
}
