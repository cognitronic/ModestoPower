using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Admin.Controllers.ViewModels;
using ModestoPower.Core.Domain.Forms;
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
    public class FormsController: BaseUserAccountController
    {
        private readonly IWaiverRepository _waiverRepository;
        public FormsController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IWaiverRepository waiverRepository,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {
            _waiverRepository = waiverRepository;
        }

        public ActionResult WaiverList()
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-forms";
            view.Waivers = _waiverRepository.GetAll();

            return View(view);
        }

        public ActionResult Waiver(string id)
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-forms";

            if (id.ToLower().Equals("new"))
            {
                view.SelectedWaiver = new Waiver();
            }
            else 
            {
                view.SelectedWaiver = _waiverRepository.GetById(id);
            }
            return View(view);
        }

        public ActionResult SaveWaiver(Waiver waiver)
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-forms";
            var w = new Waiver();
            if (!string.IsNullOrEmpty(waiver.sid))
            {
                w.Id = new MongoDB.Bson.ObjectId(waiver.sid); 
                w.datecreated = DateTime.Today;
            }
            else
            {
                w.datecreated = DateTime.Today;
            }
            w.address = waiver.address;
            w.agreedtoterms = waiver.agreedtoterms;
            w.birthday = waiver.birthday;
            w.city = waiver.city;
            w.classattending = waiver.classattending;
            w.email = waiver.email;
            w.emergencyname = waiver.emergencyname;
            w.emergencynumber = waiver.emergencynumber;
            w.first = waiver.first;
            w.guardianname = waiver.guardianname;
            w.last = waiver.last;
            w.phone = waiver.phone;
            w.state = waiver.state;
            w.zip = waiver.zip;

            view.SelectedWaiver = _waiverRepository.Save(w);
            return View("Waiver", view);
        }

        public ActionResult DeleteWaiver(string id)
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-forms";
            _waiverRepository.Delete(id);
            view.SelectedWaiver = null;
            return View(view);
        }
    }
}
