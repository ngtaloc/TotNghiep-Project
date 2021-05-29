﻿using Models.DAO;
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
		public ActionResult Meeting()
		{
			return View();

		}
		public ActionResult Tailieu()
		{
			return View();

		}
		public ActionResult Baihoc()
		{
			return View();

		}
		public ActionResult Baitap()
		{
			return View();

		}

		[ChildActionOnly]
        public ActionResult LopDaDK()
        {
            var dao = new LopHocDAO();
            var model = dao.FindLopHocHocVien(User.Identity.Name);
            return PartialView("~/Areas/HocVien/Views/Shared/LopDaDK.cshtml",model);
        }

    }
}