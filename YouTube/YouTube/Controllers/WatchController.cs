//-----------------------------------------------------------------------
// <copyright file="WatchController.cs" company="YouTube">
//     Copyright (c) YouTube. All rights reserved
// </copyright>
//-----------------------------------------------------------------------

namespace YouTube.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Controller for watch page</summary>
    public class WatchController : Controller
    {
        // GET: Watch
        public ActionResult Index()
        {
            return this.View();
        }
    }
}