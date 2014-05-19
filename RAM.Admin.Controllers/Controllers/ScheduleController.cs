using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Admin.Controllers.ViewModels;
using ModestoPower.Core.Domain.Schedule;
using RAM.Admin.Controllers.ActionArguments;
using RAM.Infrastructure.Authentication;
using RAM.Services.Interfaces;
using System.Web.Mvc;
using System.Web;
using System.IO;
using System.Configuration;
using RAM.Core;

namespace RAM.Admin.Controllers.Controllers
{
    public class ScheduleController : BaseUserAccountController
    {
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IScheduleRepository scheduleRepository,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {
            _scheduleRepository = scheduleRepository;
        }

        public ActionResult Index()
        {
            HomeView view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-schedule";
            view.ClassList = _scheduleRepository.GetAll().OrderBy(o => o.name).ThenBy(o => o.day).ToList();
            //foreach (var c in view.ClassList) {
            //    c.sid = c.Id.ToString();
            //    _scheduleRepository.Save(c);
            //}
            return View(view);

        }


        public ActionResult ScheduleList()
        {
            HomeView view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-schedule";
            view.ClassList = _scheduleRepository.GetAll().OrderBy(o => o.name).ThenBy(o => o.day).ToList();
            return Json(new
            {
                Message = "schedule saved!",
                Status = "success",
                Classes = view.ClassList
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveClass(Schedule schedule)
        {
            var s = new Schedule();


            if (string.IsNullOrEmpty(schedule.sid) || schedule.sid.Equals("000000000000000000000000"))
            {
                s.day = schedule.day.ToLower();
                s.description = schedule.description;
                s.instructor = schedule.instructor;
                s.name = schedule.name.ToLower();
                s.times = schedule.times;
                _scheduleRepository.Save(s);
                s.sid = s.Id.ToString();
                _scheduleRepository.Save(s);
            }
            else
            {
                s = _scheduleRepository.GetById(new MongoDB.Bson.ObjectId(schedule.sid));
                s.day = schedule.day.ToLower();
                s.description = schedule.description;
                s.instructor = schedule.instructor;
                s.name = schedule.name.ToLower();
                s.times = schedule.times;
                _scheduleRepository.Save(s);
            }

            return Json(new
            {
                Message = "schedule saved!",
                Status = "success",
                ScheduleID = schedule.Id.ToString()
            });
        }

        public ActionResult DeleteClass(Schedule classId)
        {
            _scheduleRepository.Delete(_scheduleRepository.GetById(new MongoDB.Bson.ObjectId(classId.sid)));
            return Json(new
            {
                Message = "schedule deleted!",
                Status = "success"
            });
        }
    }
}
