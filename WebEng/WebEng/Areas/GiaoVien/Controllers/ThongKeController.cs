using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.GiaoVien.Controllers
{
    [Authorize(Roles = "GiaoVien")]
    public class ThongKeController : Controller
    {
        // GET: GiaoVien/ThongKe
        [HttpGet]
        public ActionResult Index()
        {
            var model = new LopHocDAO().FindAll();
            ViewBag.status = -1;
            return View(model);
        }
        [HttpPost]
       public ActionResult Index(string lophoc)
        {
            var dao = new LopHocDAO();            
            int trangthai = int.Parse(lophoc);
            if (trangthai == -1)
            {
                return RedirectToAction("Index", "ThongKe");
            }
            var model = dao.FindLopHocGiaoVien(User.Identity.Name).Where(x => x.trangThai == trangthai);
            ViewBag.status = trangthai;
            return View(model);
        }

    }
}