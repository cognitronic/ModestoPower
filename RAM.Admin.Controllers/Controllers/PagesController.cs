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
using System.Web.Script.Serialization;
using System.Net;

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

        public ActionResult GetPage(string id)
        {
            var view = new HomeView();
            view.SelectedPage = _pagesRepository.GetByTitle(id.Replace("-", " "));
            switch (view.SelectedPage.title) 
            {
                case "Home":
                case "Blog":
                case "Schedule":
                case "Gallery":
                case "Contact":
                    view.UsePartialView = true;
                    break;
                default:
                    view.UsePartialView = false;
                    break;
            }
            return View(view);
        }

        public ActionResult GetPageImages(string id)
        {
            return Json(new
            {
                Message = "grabbed images ",
                Images = _pagesRepository.GetById(new MongoDB.Bson.ObjectId(id)).bannerimage
            });
        }

        public ActionResult DeleteImage(string id, string name)
        {
            var p = _pagesRepository.GetById(new MongoDB.Bson.ObjectId(id));
            var images = new List<string>();
            foreach (var image in p.bannerimage)
            {
                if (!image.Equals(name))
                {
                    images.Add(image);
                }
            }
            p.bannerimage = images;
            _pagesRepository.Save(p);
            return Json(new
            {
                Message = "image deleted"
            });
        }

        public ActionResult SaveBackgroundImages()
        {
            var p = new Pages();
            if (Request.Form.Count > 0)
            {
                if (!string.IsNullOrEmpty(Request.Form["pageID"]))
                {
                    p = (Pages)_pagesRepository.GetById(new MongoDB.Bson.ObjectId(Request.Form["pageID"]));
                }
                var list = new List<string>();
                foreach (string fileName in Request.Files)
                {
                    var file = Request.Files[fileName];
                    list.Add(ConfigurationSettings.AppSettings["PagesBGImageURL"] + file.FileName);

                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.ravenartmedia.com/%2F/ModestoPower/images/BG/" + file.FileName);
                    request.UseBinary = true;
                    request.Method = WebRequestMethods.Ftp.UploadFile;

                    // This example assumes the FTP site uses anonymous logon.
                    request.Credentials = new NetworkCredential("cognitronic", "R@mpimp1n");


                    // Copy the contents of the file to the request stream.
                    Stream stream = file.InputStream;
                    byte[] fileContents = new Byte[file.ContentLength];
                    stream.Read(fileContents, 0, fileContents.Length);
                    stream.Close();
                    stream = null;

                    
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(fileContents, 0, fileContents.Length);
                    requestStream.Close();

                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                    Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

                    response.Close();

                    //FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://www.ravenartmedia.com/%2F/ModestoPower/images/BG/" + file.FileName);
                    //request.Credentials = new NetworkCredential("cognitronic", "R@mpimp1n");
                    //request.Method = WebRequestMethods.Ftp.UploadFile;

                    //request.UsePassive = true;

                    //request.UseBinary = true;

                    //request.KeepAlive = true;

                    //using (StreamReader fileStream = new StreamReader(file.InputStream))
                    //{

                    //    byte[] buffer = Encoding.UTF8.GetBytes(fileStream.ReadToEnd());

                    //    Stream reqStream = request.GetRequestStream();

                    //    reqStream.Write(buffer, 0, buffer.Length);

                    //    reqStream.Close();

                    //}
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

        public ActionResult SavePage(Pages page)
        {
            var p = _pagesRepository.GetById(new MongoDB.Bson.ObjectId(page.sid));
            if (p != null)
            {
                p.isonline = page.isonline;
                p.bannertext = page.bannertext;
                p.headertext = page.headertext;
                p.seodescription = page.seodescription;
                p.seokeywords = page.seokeywords;
                p.maincontent = page.maincontent;
                p.lastupdated = DateTime.Now;
                _pagesRepository.Save(p);
            }

            return Json(new
            {
                Message = "image deleted"
            });
        }
    }
}
