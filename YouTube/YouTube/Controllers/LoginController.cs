//-----------------------------------------------------------------------
// <copyright file="LoginController.cs" company="YouTube">
//     Copyright (c) YouTube. All rights reserved
// </copyright>
//-----------------------------------------------------------------------

namespace YouTube.Controllers
{
    using System.Web.Mvc;
    using Repository;
    using RepositoryDAL;
    using Types;

    /// <summary>
    /// Controller for login page</summary>
    public class LoginController : Controller
    {
        /// <summary>
        /// DAL for database access</summary>
        private DAL dal = new DAL(new OracleRepository());

        /// <summary>
        /// Main action for loading page</summary>
        /// <returns>
        /// Returns the View to view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Action to process the login request</summary>
        /// <returns>
        /// Returns the View to view</returns>
        /// <param name="inputEmail">Input email</param>
        /// <param name="inputPassword">Input password</param>
        [HttpPost]
        public ActionResult Index(string inputEmail, string inputPassword)
        {
            ViewBag.LoginFailed = false;
            if (this.dal.ValidateLogin(inputEmail, inputPassword))
            {
                User user = new User(inputEmail, this.dal.GetUserChannels(inputEmail));
                this.Session["LoggedInUser"] = user;
                this.Session["ActiveChannel"] = user.ActiveChannel;
                return RedirectToAction("Index", "home");
            }
            else
            {
                ViewBag.LoginFailed = true;
            }

            return this.View();
        }
    }
}