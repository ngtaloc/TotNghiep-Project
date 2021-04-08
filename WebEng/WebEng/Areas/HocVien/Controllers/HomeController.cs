using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEng.Controllers;

namespace WebEng.Areas.HocVien.Controllers
{
    public class HomeController : Controller
    {
        // GET: HocVien/Home
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