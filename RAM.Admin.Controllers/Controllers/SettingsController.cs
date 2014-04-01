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
using ModestoPower.Core.Domain.Settings;

namespace RAM.Admin.Controllers.Controllers
{
    public class SettingsController : BaseUserAccountController
    {
        private readonly ISettingsRepository _settingsRepository;
        public SettingsController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            ISettingsRepository settingsRepository,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {
            _settingsRepository = settingsRepository;
        }

        public ActionResult Index()
        {
            HomeView view = new HomeView();
            view.Settings = _settingsRepository.GetAll().ToList<Settings>();
            view.NavView.SelectedMenuItem = "nav-settings";
            return View(view);

        }
    }
}
