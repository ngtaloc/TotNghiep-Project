using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebEng.Common;
using WebEng.Controllers;

namespace WebEng.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    public class HomeController : LayoutController
    {
        // GET: Admin/Homes

       

        public ActionResult Index()
        {

            return View();
        }

    }
}