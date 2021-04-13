using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.GiaoVien.Controllers
{
    [Authorize(Roles = "GiaoVien")]
    public class GiaoVienController : Controller
    {
        // GET: GiaoVien/GiaoVien
        public ActionResult GiaoVien()
        {
            return View();
        }
    }
}