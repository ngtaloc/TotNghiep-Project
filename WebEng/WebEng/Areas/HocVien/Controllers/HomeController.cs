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
    [Authorize(Roles = "HocVien")]
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
            var dao = new LopHocDAO();
            var model = dao.FindAll();
            return View(model);
        }
		public ActionResult chitietlophoc()
		{
			return View();
		}
	}
}