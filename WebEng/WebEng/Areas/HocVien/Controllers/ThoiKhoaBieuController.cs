using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.HocVien.Controllers
{
    [Authorize(Roles = "HocVien")]
    public class ThoiKhoaBieuController : Controller
    {
        // GET: HocVien/ThoiKhoaBieu
        public ActionResult Index()
        { 
            var dao = new NgayDAO();
            var model = dao.FindByTDN(User.Identity.Name);
            //var model = dao.FindAll();
            return View(model);
        }
    }
}