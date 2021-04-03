using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Controllers
{
    public class DangKyController : Controller
    {
        // GET: DangKy
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DKHocVien()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DKHocVien(HocVien hocVien)
        {
            return View();
        }

    }
}