using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Controllers
{
    public class HomeController : LayoutController
    {
        public ActionResult Index()
        {
            var dao = new LopHocDAO();
            var model = dao.FindAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }   

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ChiTiet(int id)
        {
            var dao = new LopHocDAO();
            var model = dao.GetByID(id);
            TimeSpan Time = model.ngayEnd.Value - model.ngayBegin.Value;
            TempData["Sothang"] = (float.Parse(Time.Days.ToString()) / 30).ToString("#");
            //ViewBag.hocvien = new HocVienDAO().FindByTDN(User.Identity.Name);
            return View(model);
        }
        [HttpPost]
        public ActionResult binhluan(int id)
        {           
            TempData["testmsg"] = "bình luận!";
            return RedirectToAction("chitiet/" + id, "Home");          
        }

    }
}