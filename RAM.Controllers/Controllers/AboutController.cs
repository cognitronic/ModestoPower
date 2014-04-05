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
using ModestoPower.Core.Domain.Forms;
using RAM.Repository.Mongo.Repositories;
using ModestoPower.Core.Domain.Client;
using MongoDB.Bson;


namespace RAM.Controllers.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IPagesRepository _pagesRepository;
        private readonly IWaiverRepository _waiverRepository;
        private readonly IClientRepository _clientRepository;
        public AboutController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IWaiverRepository waiverRepository,
            IClientRepository clientRepository,
            IPagesRepository pagesRepository,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, actionArguments)
        {
            _pagesRepository = pagesRepository;
            _waiverRepository = waiverRepository;
            _clientRepository = clientRepository;
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

        public ActionResult Waiver()
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-about";
            view.SelectedWaiver = new Waiver();
            return View(view);

        }


        public ActionResult SaveWaiver(Waiver waiver)
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-about";
            var w = new Waiver();
            w.datecreated = DateTime.Today;
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

            var client = new Client();
            client.email = waiver.email;
            client.first = waiver.first;
            client.last = waiver.last;
            client.phone = waiver.phone;
            _clientRepository.Save(client);
            return View("Waiver", view);
        }
    }
}
