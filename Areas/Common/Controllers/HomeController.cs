using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Common.Controllers
{
    public class HomeController : Controller
    {
        // GET: Common/Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult serverconnect()
        {
            return View();
        }
        [HttpGet]
        public ActionResult privacy()
        {
            return View();
        }
    }
}