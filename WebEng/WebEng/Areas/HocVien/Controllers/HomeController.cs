using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEng.Controllers;

namespace WebEng.Areas.HocVien.Controllers
{
    public class HomeController : Controller
    {
        // GET: HocVien/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}