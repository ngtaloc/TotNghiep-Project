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
            var md = new LopHocDAO().FindLopHocHocVien(User.Identity.Name);
            if (md.Count() <= 0)
            {
                return RedirectToAction("ChuaDK", "Learning");
            }
            var dao = new LopHocDAO();
            var model = dao.GetByID(id);
            return View(model);

        }
        public ActionResult ChuaDK()
        {
            return View();

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
		public ActionResult Meeting(LopHoc lopHoc, int tt) //tt=1 sắm tới : -1:cũ ; 0:all
		{
            var lh = new LopHocDAO().GetByID(lopHoc.ID);
            ViewBag.lophoc = lh;
            DateTime date;
            IEnumerable<TaiLieu> audiolist = null;
            if (lh.TaiLieux.Count() > 0)
            {
                audiolist = lh.TaiLieux.Where(x => x.idLH==lh.ID && x.idKN == null).OrderBy(x=>x.thoiGian);
               
                if (tt == 1)
                {
                    foreach (var item in audiolist)
                    {
                        if (DateTime.Compare(item.thoiGian.Date, DateTime.Now.Date) >= 0)
                        {
                            date = item.thoiGian;
                            List<TaiLieu> list = new List<TaiLieu>();
                            list.Add(item);
                            audiolist = list;
                            return View(audiolist);
                        }                           
                    }
                }       
            }
            return View(audiolist);


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

        public ActionResult Chitietbaitap(LopHoc lopHoc)
        {
            return View(lopHoc);

        }

    }
}