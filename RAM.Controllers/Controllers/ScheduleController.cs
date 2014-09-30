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
using ModestoPower.Core.Domain.Schedule;

namespace RAM.Controllers.Controllers
{
    public class ScheduleController : BaseController
    {
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IScheduleRepository scheduleRepository,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, actionArguments)
        {
            _scheduleRepository = scheduleRepository;
        }


        public ActionResult Index()
        {
            var view = new HomeView();
            view.Schedules = _scheduleRepository.GetAll().OrderBy(o => o.times).ThenBy(o => o.day).ToList();
            return View(view);
        }

    }
}
