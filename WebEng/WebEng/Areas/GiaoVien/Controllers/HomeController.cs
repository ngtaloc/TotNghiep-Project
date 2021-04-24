using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using WebEng.Controllers;

namespace WebEng.Areas.GiaoVien.Controllers
{
    [Authorize(Roles = "GiaoVien")]
    public class HomeController : LayoutController
    {
        // GET: GiaoVien/Home
       

        public ActionResult Index()
        {
            return View();
        }
    }
}