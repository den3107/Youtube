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
        /// Main action for loading page</summary>
        /// <returns>
        /// Returns the View to view</returns>
        public ActionResult Index()
        {
            List<Video> popularVideos = new List<Video>();
            popularVideos.AddRange(this.dal.GetPopularVideos(4));
            popularVideos.AddRange(this.dal.GetNewVideos(2));
            ViewBag.popularVideos = popularVideos;

            return this.View();
        }
    }
}