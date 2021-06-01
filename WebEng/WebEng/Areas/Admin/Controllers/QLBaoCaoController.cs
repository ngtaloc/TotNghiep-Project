using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.Admin.Controllers
{
    public class QLBaoCaoController : Controller
    {
        // GET: Admin/QLBaoCao
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.begig = -1;
            ViewBag.end = -1;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string date)
        {
            DateTime begin = DateTime.Parse(date.Split('-')[0]);
            DateTime end = DateTime.Parse(date.Split('-')[1]);
            DateTime now = DateTime.Now.Date;
            int result = DateTime.Compare(now, end);
            if(result<0)
            {
                return RedirectToAction("Index", "QLBaoCao");
            }
            ViewBag.begig = (now - begin).TotalDays *(-1);
            ViewBag.end = (now - end).TotalDays * (-1);

            WebEngDbContext db = new WebEngDbContext();          

            List<int> solieu = null;
            solieu[0] = db.BinhLuans.Count()+db.TaiKhoans.Count()+db.LopHocs.Count()+db.TaiLieux.Count()+db.LichSuGDs.Count()+db.DSLopHocs.Count();
            ViewBag.thongkeDau=0;
            return View();
        }
    }
}