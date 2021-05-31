using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.HocVien.Controllers
{
    [Authorize(Roles = "HocVien")]
    public class LearningController : Controller
    {
        // GET: HocVien/Learning
        public ActionResult Index(int id=1)
        {
            var dao = new LopHocDAO();
            var model = dao.GetByID(id);
            return View(model);

        }
		 public ActionResult Listening(LopHoc lopHoc)
        {
            return View(lopHoc);

        }
		public ActionResult Speaking(LopHoc lopHoc)
		{
			return View(lopHoc);

		}
		public ActionResult Reading(LopHoc lopHoc)
		{
			return View(lopHoc);

		}
		public ActionResult Writing(LopHoc lopHoc)
		{
			return View(lopHoc);

		}
		public ActionResult OnlineClass(LopHoc lopHoc)
		{
			return View(lopHoc);

		}
		public ActionResult Meeting(LopHoc lopHoc)
		{
			return View(lopHoc);

		}
		public ActionResult Tailieu(LopHoc lopHoc, int idkn)
		{
            var lh = new LopHocDAO().GetByID(lopHoc.ID);
            IEnumerable<TaiLieu> model = null;
            if (lh.TaiLieux.Count() > 0) { model = lh.TaiLieux.Where(x => x.idKN == idkn); }
            return View(model);
		}
        [HttpGet]
        public ActionResult XemCK(int ID)
        {
            var dao = new TaiLieuDAO();
            var model = dao.GetByID(ID);
            return PartialView("XemCK", model);
        }


        public ActionResult Baihoc(LopHoc lopHoc)
		{
			return View(lopHoc);

		}
		public ActionResult Baitap(LopHoc lopHoc)
		{
			return View(lopHoc);

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