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
    using Repository;
    using RepositoryDAL;
    using Types;

    /// <summary>
    /// Controller for watch page</summary>
    public class WatchController : Controller
    {
        /// <summary>
        /// DAL for database access</summary>
        private DAL dal = new DAL(new OracleRepository());

        /// <summary>
        /// Action for loading video with it's comments. Returns custom 404-page if video link not found.</summary>
        /// <returns>
        /// Returns the View to view</returns>
        /// <param name="v">Video link of video</param>
        public ActionResult Index(string v)
        {
            //// Set css file
            ViewBag.cssName = "watch";

            if (!this.dal.DoesVideoLinkExist(v))
            {
                return this.View("watch404");
            }

            Video video = this.dal.GetVideo(v);

            //// Add 1 to view count!
            video.AddView();

            ViewBag.video = video;

            return this.View();
        }

        /// <summary>
        /// Action to subscribe the user to the channel</summary>
        /// <returns>
        /// Returns the index view</returns>
        /// <param name="channelId">ChannelId to subscribe on</param>
        /// <param name="v">Video link of video</param>
        public ActionResult Subscribe(int channelId, string v)
        {
            Channel channel = Session["ActiveChannel"] as Channel;

            // Add subscription
            channel.AddSubscription(this.dal.GetChannel(channelId));

            return this.RedirectToAction("Index", new { v = v });
        }

        /// <summary>
        /// Action to unsubscribe the user of the channel</summary>
        /// <returns>
        /// Returns the index view</returns>
        /// <param name="channelId">ChannelId to unsubscribe from</param>
        /// <param name="v">Video link of video</param>
        public ActionResult Unsubscribe(int channelId, string v)
        {
            Channel channel = Session["ActiveChannel"] as Channel;

            // Look for subscription with given ID
            for (int i = 0; i < channel.Subscriptions.Count; i++)
            {
                if (channel.Subscriptions[i].ChannelId == channelId)
                {
                    // remove found subscription
                    channel.RemoveSubscription(channel.Subscriptions[i]);
                }
            }
            
            return this.RedirectToAction("Index", new { v = v });
        }
    }
}