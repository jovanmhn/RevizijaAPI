using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RevizijaAPI.Models.Database;

namespace RevizijaAPI.Controllers
{
    public class HomeController : Controller
    {
        public RedirectResult RedirectToAspx()
        {
            return Redirect("~/Pages/TestHome/TestHome.aspx");
        }
        public ActionResult Index()
        {
            //ViewBag.Title = "Home Page";
            return RedirectToAspx();
            return View();
        }
    }
}
