using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.GiaoVien.Controllers
{
    [Authorize(Roles = "GiaoVien")]
    public class QLLopHocController : Controller
    {
        // GET: GiaoVien/QLLopHoc
        public ActionResult Index(int idlh)
        {
            var model = new LopHocDAO().GetByID(idlh);
            return View(model);
        }
        public ActionResult InfoLH(LopHoc lopHoc)
        {
            return View(lopHoc);

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
        public ActionResult Tailieu(LopHoc lopHoc, int idkn)
        {
            var lh = new LopHocDAO().GetByID(lopHoc.ID);
            IEnumerable<TaiLieu> model = null;
            if (lh.TaiLieux.Count() > 0) { model = lh.TaiLieux.Where(x => x.idKN == idkn); }
            return View(model);
        }
        public ActionResult Baitap(LopHoc lopHoc)
        {
            return View(lopHoc);

        }
    }
}