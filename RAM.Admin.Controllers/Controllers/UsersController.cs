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
            var u = new User();


            if (user.PasswordAnswer == null || user.PasswordAnswer.Equals("000000000000000000000000"))
            {
                u.EnteredBy = SecurityContextManager.Current.CurrentUser.Id;
                u.DateCreated = DateTime.Now;
                u.AccessLevel = 60;
                u.IsActive = true;
                u.LastLoginDate = DateTime.Now;
                u.PasswordAnswer = user.Password;
                u.PasswordQuestion = user.Password;
                u.LastUpdated = DateTime.Now;
                u.ChangedBy = SecurityContextManager.Current.CurrentUser.Id;
                _userService.CreateNewUser(user);
            }
            else
            {
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.Email = user.Email;
                if (!string.IsNullOrEmpty(user.Password))
                {
                    u.Password = user.Password;
                }
                u.LastUpdated = DateTime.Now;
                u.ChangedBy = SecurityContextManager.Current.CurrentUser.Id;
                u.Id = new MongoDB.Bson.ObjectId(user.PasswordAnswer);
                _userService.UpdateUser(u);
            }

            return Json(new
            {
                Message = "user saved!",
                Status = "success",
                UserID = user.Id
            });
        }

        public ActionResult DeleteUser(string id)
        {
            _userService.DeleteUser(_userService.FindByEmail(id));
            return Json(new
            {
                Message = "user deleted!",
                Status = "success"
            });
        }
    }
}
