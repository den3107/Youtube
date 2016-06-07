using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouTube.Types;
using YouTube.RepositoryDAL;
using YouTube.Repository;

namespace YouTube.Controllers
{
    public class HomeController : Controller
    {
        DAL dal = new DAL(new OracleRepository());

        // GET: Home
        public ActionResult Index()
        {
            List<Video> popularVideos = new List<Video>();
            popularVideos.AddRange(dal.GetPopularVideos(4));
            popularVideos.AddRange(dal.GetNewVideos(2));
            ViewBag.popularVideos = popularVideos;

            return View();
        }
    }
}