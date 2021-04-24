using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebEng.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout\
<<<<<<< HEAD
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            var dao = new TaiKhoanDAO();
            var model = dao.FindAll();
            return View(model);
        }
        //[ChildActionOnly]
        //public ActionResult MainHeader()
        //{
        //    return PartialView();
        //}
        //[ChildActionOnly]
        //public ActionResult MainSidebar()
        //{
        //    var dao = new TaiKhoanDAO();
        //    var model = dao.GetByTDN(User.Identity.Name);
            
        //    return PartialView("~/Views/Shared/MainSidebar.cshtml", model);
        //}
=======

        [ChildActionOnly]
        public ActionResult MainHeader()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult MainSidebar()
        {
            var dao = new TaiKhoanDAO();
            var model = dao.GetByTDN(User.Identity.Name);

            return PartialView("~/Views/Shared/MainSidebar.cshtml", model);
        }

>>>>>>> ecb2372368cf12c3f4375806e69a76e6b0fb22a3
        [Authorize(Roles = "GiaoVien")]
        public ActionResult gv()
        {
           
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("", "");
        }

        public ActionResult ChucNang()
        {
            var dao = new ChucNangDAO();
            var model = dao.FindAll();
            return View(model);
        }
    }
}