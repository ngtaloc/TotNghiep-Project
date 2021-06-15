using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.HocVien.Controllers
{
    [Authorize(Roles = "HocVien")]
    public class LearningController : Controller
    {
        // GET: HocVien/Learning
        public ActionResult Index(int id=0)
        {
            var dao = new LopHocDAO();
            var md = dao.FindLopHocHocVien(User.Identity.Name);
            if (md.Count() <= 0)
            {
                return RedirectToAction("ChuaDK", "Learning");
            }
            if (id == 0)
            {                
                return View(md.First());
            }
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
                        if (DateTime.Compare(item.thoiGian, DateTime.Now) >= 0)
                        {
                            date = item.thoiGian;
                            List<TaiLieu> list = new List<TaiLieu>();
                            list.Add(item);
                            audiolist = list;
                            return View(audiolist);
                        }                           
                    }
                    return View(audiolist);
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
		public ActionResult Baitap(LopHoc lopHoc, int idkn)
		{
            var lh = new LopHocDAO().GetByID(lopHoc.ID);
            ViewBag.lophoc = lh;
            ViewBag.idkn = idkn;
            IEnumerable<TaiLieu> audiolist = null;
            if (lh.TaiLieux.Count() > 0) { audiolist = lh.TaiLieux.Where(x => x.idLH==lopHoc.ID && x.idKN == idkn && !string.IsNullOrEmpty(x.idBT.ToString())); }
            return View(audiolist);

        }

		[ChildActionOnly]
        public ActionResult LopDaDK()
        {
            var dao = new LopHocDAO();
            var model = dao.FindLopHocHocVien(User.Identity.Name);
            
            return PartialView("~/Areas/HocVien/Views/Shared/LopDaDK.cshtml",model);
        }

        [HttpGet]
        public ActionResult Chitietbaitap(int idbt)
        {
            var dao = new BaiTapDAO();
            var model = dao.GetByID(idbt);
            ViewBag.CountSubmit = dao.CountSubmit(idbt);
            var hv= new HocVienDAO().FindByTDN(User.Identity.Name);
            ViewBag.hv = hv;
            List<TraLoi> tralois = new List<TraLoi>();
            foreach(var i in model.CauHois)
            {
                var tl = new TraLoi();
                tl.CauHoi = i;
                tl.idCauHoi = i.ID;
                tl.HocVien = hv;
                tl.idHV = hv.id;
                tralois.Add(tl);
            }
            ViewBag.tralois = tralois;
            string d =null;
            DateTime timenop;
            int timeLam=0;
            if(hv.fileTraLois.Where(x=>x.idBT==idbt).Count()>0 || hv.TraLois.Where(x=>x.CauHoi.idBT==idbt).Count() > 0)
            {
                d = new TraLoiDAO().Diem(idbt, hv.id);
                try
                {
                    timenop = hv.fileTraLois.Where(x => x.idBT == idbt).FirstOrDefault().thoiGian;
                    ViewBag.timenop = timenop;
                    timeLam =Convert.ToInt32(hv.fileTraLois.Where(x => x.idBT == idbt).FirstOrDefault().tgLamBai);
                    ViewBag.timeLam = timeLam;
                }
                catch
                {
                    timenop = hv.TraLois.Where(x => x.CauHoi.idBT == idbt).FirstOrDefault().thoiGian;
                    ViewBag.timenop = timenop;
                    timeLam = Convert.ToInt32(hv.TraLois.Where(x => x.CauHoi.idBT == idbt).FirstOrDefault().tgLamBai);
                    ViewBag.timeLam = timeLam;
                }
            }
            ViewBag.diem = d;
            ViewBag.timeLam = timeLam;
            if (string.IsNullOrEmpty(Session[idbt.ToString()] as string)) 
            {
                try
                {
                    DateTime dt = DateTime.Now.AddMinutes(double.Parse(model.thoiGianLamBai.ToString()));
                    Session[idbt.ToString()] = dt.ToString();
                }
                catch
                {
                    Session[idbt.ToString()] = "";
                }
                
            }
           
            string ttt = Session[idbt.ToString()].ToString();

            return View("Chitietbaitap", model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChitietbaitapSubmit(List<TraLoi> tralois, HttpPostedFileBase file, int idbt)
        {
            var hv = new HocVienDAO().FindByTDN(User.Identity.Name);
            DateTime now = DateTime.Now;
            DateTime tsubmit = DateTime.Parse(Session[idbt.ToString()].ToString());
            double phut = tsubmit.Subtract(now).TotalMinutes;
            if (file != null && file.ContentLength > 0)
            {
                var dao = new fileTraLoiDAO();
                string _FileName = Path.GetFileName(file.FileName);
                string path = "Content/Data/traloi/hv" + hv.id+"/bt" + idbt + "/";
                string _path = Path.Combine(Server.MapPath("~/" + path), _FileName);
                Directory.CreateDirectory(Path.Combine(Server.MapPath("~/" + path)));
                file.SaveAs(_path);
                int fileSize = file.ContentLength;
                int Size = fileSize / 1000000;
                var filetl = new fileTraLoi();
                filetl.ten = _FileName;
                filetl.FileSize = Size;
                filetl.link = "~/" + _FileName;
                filetl.idBT = idbt;
                filetl.thoiGian = DateTime.Now;
                filetl.idHV = hv.id;
                filetl.trangThai = 1;           //0:dong 1:mo
                filetl.tgLamBai = Convert.ToInt32(phut);
                dao.Insert(filetl);
            }
            //else
            //{
            //    var dao = new fileTraLoiDAO();

            //    var filetl = new fileTraLoi();
            //    filetl.idBT = idbt;
            //    filetl.thoiGian = DateTime.Now;
            //    filetl.idHV = hv.id;
            //    filetl.trangThai = 1;           //0:dong 1:mo
            //    dao.Insert(filetl);
            //}
            var daotl = new TraLoiDAO();
            foreach (var item in tralois)
            {
                var tl = new TraLoi();
                tl.idCauHoi = item.idCauHoi;
                tl.DapAn = item.DapAn;
                tl.idHV = hv.id;
                tl.thoiGian = DateTime.Now;
                tl.tgLamBai = Convert.ToInt32(phut);
                daotl.Insert(tl);
            }
            TempData["testmsg"] = "Nộp bài thành công.";
            Session.Clear();
            return RedirectToAction("Chitietbaitap", "Learning", new { idbt = idbt });
            //return RedirectToAction("Index", "Learning");

        }
        //Show THỜI GIAN LÀM BÀI 
    }
}