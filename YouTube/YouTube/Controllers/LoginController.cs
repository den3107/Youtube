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
        public ActionResult Index()
        {
            ViewBag.LoginFailed = false;
            if (Request.HttpMethod == "POST")
            {
                string email = Request["inputEmail"];
                string password = Request["inputPassword"];

                if (this.dal.ValidateLogin(email, password))
                {
                    User user = new User(email, this.dal.GetUserChannels(email));
                    this.Session["LoggedInUser"] = user;
                    this.Session["ActiveChannel"] = user.ActiveChannel;
                    Response.Redirect("/", true);
                }
                else
                {
                    ViewBag.LoginFailed = false;
                }
            }

            return this.View();
        }
    }
}