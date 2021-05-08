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
       
        [ChildActionOnly]
        public ActionResult MainHeader()
        {
            var dao = new TaiKhoanDAO();
            
            try
            {
                var model = dao.GetByTDN(User.Identity.Name);
                return PartialView("~/Views/Shared/MainHeader.cshtml", model);
            }
            catch
            {
                return PartialView("~/Views/Shared/MainHeader.cshtml");
            }
            
            
        }
        [ChildActionOnly]
        public ActionResult MainSidebar()
        {
            var dao = new TaiKhoanDAO();
            try
            {
                var model = dao.GetByTDN(User.Identity.Name);
                return PartialView("~/Views/Shared/MainSidebar.cshtml", model);
            }
            
            catch
            {
                return PartialView("~/Views/Shared/MainSidebar.cshtml");
            }
           
        }
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