using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Infrastructure.Authentication;
using RAM.Services.Interfaces;
using RAM.Controllers.ActionArguments;
using RAM.Controllers.ViewModels;
using RAM.Core.Domain.Subscriber;
using System.Web.Mvc;

namespace RAM.Controllers.Controllers
{
    public class SubscriberController : BaseController
    {
        public SubscriberController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, actionArguments)
        {
        }


        public ActionResult Index()
        {
            var view = new HomeView();
            return PartialView("_Subscribe", view);

        }

        public ActionResult SubscribeToNewsletter(Subscriber subscriber)
        { 
            return Json(new
            {
                Message = "You've been successfully added to the list!",
                Status = "success"
            });
        }
    }
}
