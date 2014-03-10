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
using RAM.Core;

namespace RAM.Admin.Controllers.Controllers
{
    public class UsersController : BaseUserAccountController
    {
        public UsersController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {

        }

        public ActionResult Index()
        {
            HomeView view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-users";
            view.Users = _userService.FindAll();
            return View(view);

        }

        public ActionResult UserList()
        {
            HomeView view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-users";
            view.Users = _userService.FindAll();

            return PartialView("_UserList", view);
        }

        public ActionResult SaveUser(User user)
        {
            user.LastUpdated = DateTime.Now;
            user.ChangedBy = SecurityContextManager.Current.CurrentUser.Id;
            if (user.Id == null || user.Id.ToString().Equals("000000000000000000000000"))
            {
                user.EnteredBy = SecurityContextManager.Current.CurrentUser.Id;
                user.DateCreated = DateTime.Now;
                user.AccessLevel = 60;
                user.IsActive = true;
                user.LastLoginDate = DateTime.Now;
                user.PasswordAnswer = user.Password;
                user.PasswordQuestion = user.Password;
                _userService.CreateNewUser(user);
            }
            else
            {
                _userService.UpdateUser(user);
            }

            return Json(new
            {
                Message = "user saved!",
                Status = "success",
                UserID = user.Id
            });
        }
    }
}
