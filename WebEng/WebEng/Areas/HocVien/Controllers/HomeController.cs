using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebEng.Controllers;

namespace WebEng.Areas.HocVien.Controllers
{
<<<<<<< HEAD
    //[Authorize(Roles = "HocVien")]
    public class HomeController : Controller
    {
        // GET: HocVien/Home
        [ChildActionOnly]
        public ActionResult MainHeader()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult MainSidebar()
        {
            var dao = new TaiKhoanDAO();
            //var model = dao.GetByTDN(User.Identity.Name);
            var model = dao.GetByTDN("minhhau");

            return PartialView("~/Views/Shared/MainSidebar.cshtml", model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
=======
    [Authorize(Roles = "HocVien")]
    public class HomeController : LayoutController
    {
        // GET: HocVien/Home
      
>>>>>>> ecb2372368cf12c3f4375806e69a76e6b0fb22a3

        public ActionResult Index()
        {
            var dao = new LopHocDAO();
            var model = dao.FindAll();
            return View(model);
        }
		public ActionResult chitietlophoc()
		{
			return View();
		}
		public ActionResult learning()
		{
			return View();
		}
	}
}