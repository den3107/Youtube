using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouTube.RepositoryDAL;
using YouTube.Repository;
using YouTube.Types;

namespace YouTube.Controllers
{
    public class LoginController : Controller
    {
        DAL dal = new DAL(new OracleRepository());

        // GET: Login
        public ActionResult Index()
        {
            ViewBag.LoginFailed = false;
            if(Request.HttpMethod == "POST")
            {
                String email = Request["inputEmail"];
                String password = Request["inputPassword"];

                if(dal.ValidateLogin(email, password))
                {
                    User user = new User(email, dal.GetUserChannels(email));
                    Session["LoggedInUser"] = user;
                    user.SetActivechannel(0);
                    Session["ActiveChannel"] = user.ActiveChannel;
                    Response.Redirect("/", true);
                }
                else
                {
                    ViewBag.LoginFailed = false;
                }
            }
            return View();
        }
    }
}