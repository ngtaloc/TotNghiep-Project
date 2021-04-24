using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
<<<<<<< HEAD
=======
using WebEng.Controllers;
>>>>>>> ecb2372368cf12c3f4375806e69a76e6b0fb22a3

namespace WebEng.Areas.GiaoVien.Controllers
{
    [Authorize(Roles = "GiaoVien")]
<<<<<<< HEAD
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
=======
    public class HomeController : LayoutController
    {
        // GET: GiaoVien/Home
       
>>>>>>> ecb2372368cf12c3f4375806e69a76e6b0fb22a3
        public ActionResult Index()
        {
            return View();
        }
    }
}