//-----------------------------------------------------------------------
// <copyright file="LogoutController.cs" company="YouTube">
//     Copyright (c) YouTube. All rights reserved
// </copyright>
//-----------------------------------------------------------------------

namespace YouTube.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Controller for logging out</summary>
    public class LogoutController : Controller
    {
        /// <summary>
        /// Action to clear user login data (logout)</summary>
        /// <returns>
        /// Returns the View to view</returns>
        public ActionResult Index()
        {
            this.Session["LoggedInUser"] = null;
            this.Session["ActiveChannel"] = null;

            //// Head back to main page
            return this.RedirectToAction("Index", "Home");
        }
    }
}