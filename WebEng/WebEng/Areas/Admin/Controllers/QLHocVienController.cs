using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QLHocVienController : Controller
    {
        // GET: Admin/QLHocVien
        public ActionResult Index()
        {
            return View();
        }
    }
}