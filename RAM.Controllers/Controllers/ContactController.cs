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
using IdeaSeed.Core.Mail;
using System.Configuration;



namespace RAM.Controllers.Controllers
{
    public class ContactController : BaseController
    {
        public ContactController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, actionArguments)
        {
            //_userService = userService;
        }


        public ActionResult Index()
        {
            var view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-contact";
            return View(view);

        }

        public ActionResult SendMessage()
        {
            string body = "<b>Name: </b>" + Request.Form["field_name"] + "<br />" +
                "<b>Email: </b>" + Request.Form["field_email"] + "<br />" +
                "<b>Phone: </b>" + Request.Form["field_phone"] + "<br />" +
                "<b>Message: </b>" + Request.Form["field_message"] + "<br /><h2>Interests:</h2><br />";
            if (Request.Form["interestedbjj"] != null)
            {
                body += "<span><b>Jiu Jitsu </b></span><br />";
            }
            if (Request.Form["interestedmuaythai"] != null)
            {
                body += "<span><b>Muay Thai </b></span><br />";
            }
            if (Request.Form["interestedmma"] != null)
            {
                body += "<span><b>MMA </b></span><br />";
            }
            if (Request.Form["interestedkickboxing"] != null)
            {
                body += "<span><b>Cardio Kickboxing </b></span><br />";
            }
            if (Request.Form["interestedtpl"] != null)
            {
                body += "<span><b>The Performance Lab </b></span><br />";
            }
            if (Request.Form["interestedpeak"] != null)
            {
                body += "<span><b>Peak Physique </b></span><br />";
            }
            if (Request.Form["interestedweightloss"] != null)
            {
                body += "<span><b>Weight Loss </b></span><br />";
            }
            if (Request.Form["interestedstrength"] != null)
            {
                body += "<span><b>Increase Strength </b></span><br />";
            }

            try
            {
                EmailUtils.SendEmail(ConfigurationSettings.AppSettings["ContactMessageToAddress"],
                    ConfigurationSettings.AppSettings["ContactMessageFromAddress"],
                    "",
                    ConfigurationSettings.AppSettings["ContactMessageBccAddress"],
                    Request.Form["field_subject"],
                    body,
                    false,
                    ""
                    );
            }
            catch (Exception exc)
            {
                return Json(new
                {
                    Message = "Message did not send.  Please call " + ConfigurationSettings.AppSettings["PhoneNumber"],
                    Status = "fail"
                });
            }
            return Json(new
            {
                Message = "Your message has been received and someone will be in contact shortly, thanks!!",
                Status = "success"
            });
        }
    }
}
