using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEng.Common;
using WebEng.Controllers;

namespace WebEng.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Homes

        
        public ActionResult Index()
        {
          
            return View();
        }
       
    }
}