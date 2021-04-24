using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebEng.Common;
using WebEng.Controllers;

namespace WebEng.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
<<<<<<< HEAD
    public class HomeController : Controller
    {
        // GET: Admin/Homes

        
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
            return RedirectToAction("", "");
        }


=======
    public class HomeController : LayoutController
    {
        // GET: Admin/Homes

       
>>>>>>> ecb2372368cf12c3f4375806e69a76e6b0fb22a3
        public ActionResult Index()
        {

            return View();
        }
    }
}