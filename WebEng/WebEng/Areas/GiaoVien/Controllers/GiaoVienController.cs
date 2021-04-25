using Models.DAO;
using Models.Framework;
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
            var dao = new LopHocDAO();
            var model = dao.FindLopHocGiaoVien(User.Identity.Name);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new LopHoc();
            return PartialView("Create", model);
        }

        [HttpPost]
        public ActionResult Create(LopHoc lophoc, bool Listening=false, bool Speaking = false, bool Reading = false, bool Writing = false)
        {
            if (ModelState.IsValid)
            {
                var dao = new LopHocDAO();
                int kt = dao.Insert(lophoc);
                if (kt >=0)
                {
                    ModelState.AddModelError("", "Tạo lớp thành công");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo lớp không thành công");
                }
            }
            return View("Index");
        }
    }
}