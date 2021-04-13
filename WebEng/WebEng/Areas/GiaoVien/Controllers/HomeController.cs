using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebEng.Areas.GiaoVien.Controllers
{
    [Authorize(Roles = "GiaoVien")]
    public class HomeController : Controller
    {
        // GET: GiaoVien/Home
       
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
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}