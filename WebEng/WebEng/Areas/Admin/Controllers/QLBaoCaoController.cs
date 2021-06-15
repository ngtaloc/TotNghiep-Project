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
            ViewBag.begig = 0;
            ViewBag.end = 0;
            WebEngDbContext db = new WebEngDbContext();
            DateTime now = DateTime.Now.AddDays(-1).Date;
            List<int> solieu = new List<int>();
            IEnumerable<LichSuGD> gd = db.LichSuGDs.Where(x=>x.LoaiGD == 0);
            int danhthu = 0;
            foreach (var it in gd)
            {
                danhthu += it.SoTienGD;
            }

            IEnumerable<LopHoc> listLH = db.LopHocs;
            IEnumerable<TaiKhoan> listTK = db.TaiKhoans;
            IEnumerable<LichSuGD> listGD = db.LichSuGDs;
            int tl = 0;
            try
            {
                tl = db.TraLois.GroupBy(x => new { x.idHV, x.CauHoi.BaiTap }).Count();
            }
            catch { }
            //Tương tác
            solieu.Add(db.BinhLuans.Count()
                + listTK.Count()
                + listLH.Count()
                + db.TaiLieux.Count()
                + listGD.Count()
                + db.DSLopHocs.Count()
                + db.BaiTaps.Count()
                + tl
                + db.fileTraLois.Count());
            
            solieu.Add(danhthu);            //danh thu           
            solieu.Add(listLH.Count());     //mở lớp 
            solieu.Add(listTK.Count());     //new menber

            ViewBag.thongkeDau = solieu;
            ViewBag.listLH = listLH;
            ViewBag.listTK = listTK;
            ViewBag.listGD = listGD;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string date)
        {
            DateTime begin = DateTime.Parse(date.Split('-')[0]);
            DateTime end = DateTime.Parse(date.Split('-')[1]);
            DateTime now = DateTime.Now.Date;
            int result = DateTime.Compare(now, end);
            if(result<=0)
            {
                TempData["testmsg"] = "Chọn ngày phải bé hơn ngày hiện tại.";
                return RedirectToAction("Index", "QLBaoCao");
            }
            ViewBag.begig = (now - begin).TotalDays *(-1);
            ViewBag.end = (now - end).TotalDays * (-1);

            WebEngDbContext db = new WebEngDbContext();          

            List<int> solieu = new List<int>();           
            IEnumerable<LichSuGD> gd = db.LichSuGDs.Where(x => DateTime.Compare(begin, x.ThoiGiangGD) <=0 && DateTime.Compare(end, x.ThoiGiangGD)>=0 && x.LoaiGD == 0);
            int danhthu = 0;
             foreach (var it in gd)
            {
                danhthu += it.SoTienGD;
            }
            int tl = 0;
            try
            {
                tl = db.TraLois.Where(x => DateTime.Compare(begin, x.thoiGian) <= 0 && DateTime.Compare(end, x.thoiGian) >= 0).GroupBy(x => new { x.idHV, x.CauHoi.BaiTap }).Count();
            }
            catch { }
            var listLH = db.LopHocs.Where(x => DateTime.Compare(begin, x.ngayDangKy) <= 0 && DateTime.Compare(end, x.ngayDangKy) >= 0);
            var listTK = db.TaiKhoans.Where(x => DateTime.Compare(begin, x.ngayDangKy)<=0 && DateTime.Compare(end, x.ngayDangKy) >=0);
            var listGD = db.LichSuGDs.Where(x => DateTime.Compare(begin, x.ThoiGiangGD) <= 0 && DateTime.Compare(end, x.ThoiGiangGD) >= 0);
            //Tương tác
            solieu.Add(db.BinhLuans.Where(x =>DateTime.Compare(begin, x.thoiGian)<=0 && DateTime.Compare(end, x.thoiGian)>=0).Count()
                + listTK.Count()
                + listLH.Count()
                + db.TaiLieux.Where(x => DateTime.Compare(begin, x.thoiGian)<=0 && DateTime.Compare(end, x.thoiGian) >= 0).Count()
                + listGD.Count()
                + db.DSLopHocs.Where(x => DateTime.Compare(begin, x.ngaydDangKy) <= 0 && DateTime.Compare(end, x.ngaydDangKy) >= 0).Count()
                + db.BaiTaps.Where(x => DateTime.Compare(begin, x.ngayDang) <= 0 && DateTime.Compare(end, x.ngayDang) >= 0).Count()
                + tl
                + db.fileTraLois.Where(x => DateTime.Compare(begin, x.thoiGian) <= 0 && DateTime.Compare(end, x.thoiGian) >= 0).Count());
            //danh thu
            solieu.Add(danhthu);
            //mở lớp
            solieu.Add(listLH.Count());
            //new menber
            solieu.Add(listTK.Count());
            ViewBag.thongkeDau = solieu;
            ViewBag.listLH = listLH;
            ViewBag.listTK = listTK;
            ViewBag.listGD = listGD;
            return View();
        }
    }
}