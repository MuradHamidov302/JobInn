using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobInn.Areas.UserPage.Controllers
{
    public class HomeController : Controller
    {
        // GET: UserPage/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}