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
    public class HomeController : LayoutController
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