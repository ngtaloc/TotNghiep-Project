using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QLGiaoVienController : Controller
    {
        // GET: Admin/QLGiaoVien
        public ActionResult Index()
        {
            var dao = new GiangVienDAO();
            var model = dao.FindAll();
            
            return View(model);
        }

        public ActionResult Tim(string tim)
        {
            var dao = new GiangVienDAO();
            var model = dao.Tim(tim);

            return View("Index",model);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var dao = new GiangVienDAO();
            var model = dao.GetByID(ID);
            return PartialView("Edit",model);
        }

        [HttpPost]
        public ActionResult Edit(Giangvien giangvien)
        {
            if (ModelState.IsValid)
            {
                var dao = new GiangVienDAO();
                bool kt = dao.Update(giangvien,giangvien.TaiKhoan.tenDangNhap);
                if (kt)
                {
                    ModelState.AddModelError("", "Cập nhât thành công");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhât không thành công");
                }
            }
            return View("Index");
        }

        public ActionResult Lock(int id)
        {
            if (ModelState.IsValid)
            {

                var dao = new GiangVienDAO();
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