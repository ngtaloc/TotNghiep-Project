using Models.DAO;
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
            var dao = new HocVienDAO();
            var model = dao.FindAll();

            return View(model);
        }

        public ActionResult Tim(string tim)
        {
            var dao = new HocVienDAO();
            var model = dao.Tim(tim);
            return View("Index", model);
        }
        public ActionResult Lock(int id)
        {
            if (ModelState.IsValid)
            {

                var dao = new HocVienDAO();
                bool kt = dao.Khoa(id);
                if (kt)
                {
                    ModelState.AddModelError("", "Khóa thành công");

                }
                else
                {
                    ModelState.AddModelError("", "khóa không thành công");
                }
            }
            return RedirectToAction("Index");
        }
    }
}