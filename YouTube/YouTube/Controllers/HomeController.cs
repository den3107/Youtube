//-----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="YouTube">
//     Copyright (c) YouTube. All rights reserved
// </copyright>
//-----------------------------------------------------------------------

namespace YouTube.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Repository;
    using RepositoryDAL;
    using Types;

    /// <summary>
    /// Controller for home page</summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// DAL for database access</summary>
        private DAL dal = new DAL(new OracleRepository());

        /// <summary>
        /// Action for loading page, optionally changing active channel to newChannel</summary>
        /// <returns>
        /// Returns the View to view</returns>
        /// <param name="newChannel">Channel name to set active</param>
        public ActionResult Index(string newChannel = null)
        {
            List<Video> popularVideos = new List<Video>();
            popularVideos.AddRange(this.dal.GetPopularVideos(4));
            popularVideos.AddRange(this.dal.GetNewVideos(2));
            ViewBag.popularVideos = popularVideos;

            if (this.Session["LoggedInUser"] != null && newChannel != null)
            {
                User user = Session["LoggedInUser"] as User;
                for (int i = 0; i < user.Channels.Count; i++)
                {
                    if (user.Channels[i].Name == newChannel)
                    {
                        user.SetActivechannel(i);
                        this.Session["ActiveChannel"] = user.ActiveChannel;
                        break;
                    }
                }
            }

            return this.View();
        }
    }
}