using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.GiaoVien.Controllers
{
    [Authorize(Roles = "GiaoVien")]
    public class ThoiKhoaBieuController : Controller
    {
        // GET: GiaoVien/ThoiKhoaBieu
        public ActionResult Index()
        {
            var dao = new NgayDAO();
            var model = dao.FindByTDNGV(User.Identity.Name);
            //var model = dao.FindAll();
            return View(model);
        }
    }
}