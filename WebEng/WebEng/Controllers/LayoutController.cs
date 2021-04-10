using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult MainHeader()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult MainSidebar()
        {

            return PartialView();
        }
        public ActionResult ChucNang()
        {
            var dao = new ChucNangDAO();
            var model = dao.FindAll();
            return View(model);
        }
    }
}