using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.HocVien.Controllers
{
    public class LearningController : Controller
    {
        // GET: HocVien/Learning
        public ActionResult Index()
        {
            return View();

        }
		 public ActionResult Listening()
        {
            return View();

        }
		public ActionResult Speaking()
		{
			return View();

		}
		public ActionResult Reading()
		{
			return View();

		}
		public ActionResult Writing()
		{
			return View();

		}
		public ActionResult OnlineClass()
		{
			return View();

		}
	}
}