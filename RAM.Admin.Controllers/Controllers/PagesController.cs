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
            view.NavView.SelectedMenuItem = "nav-pages";
            return View(view);

        }

        public ActionResult Home()
        {
            HomeView view = new HomeView();
            view.SelectedPage = _pagesRepository.GetByTitle("Home");
            view.NavView.SelectedMenuItem = "nav-pages";
            return View("Home", view);
        }

        public ActionResult GetPageImages(string id)
        {
            return Json(new
            {
                Message = "grabbed images ",
                Images = _pagesRepository.GetById(new MongoDB.Bson.ObjectId(id)).bannerimage
            });
        }

        public ActionResult SaveBackgroundImages()
        {
            var p = new Pages();
            if (Request.Form.Count > 0)
            {
                if (!string.IsNullOrEmpty(Request.Form["pageID"]))
                {
                    p = _pagesRepository.GetById(new MongoDB.Bson.ObjectId(Request.Form["pageID"]));
                }
                var list = new List<string>();
                foreach (string fileName in Request.Files)
                {
                    var file = Request.Files[fileName];
                    list.Add(ConfigurationSettings.AppSettings["PagesBGImageURL"] + file.FileName);
                    file.SaveAs(ConfigurationSettings.AppSettings["PagesBGImageDir"] + file.FileName);
                }
                foreach (var i in p.bannerimage) 
                {
                    list.Add(i);
                }
                p.bannerimage = list;
                _pagesRepository.Save(p);
            }
            return Json(new
            {
                Message = "images saved ",
                Status = "success"
            });
        }
    }
}
