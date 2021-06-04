using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.GiaoVien.Controllers
{
    [Authorize(Roles = "GiaoVien")]
    public class QLLopHocController : Controller
    {
        // GET: GiaoVien/QLLopHoc
        public ActionResult Index(int id)
        {
            var model = new LopHocDAO().GetByID(id);
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
        [HttpGet]
        public ActionResult Tailieu(LopHoc lopHoc, int idkn)
        {
            var lh = new LopHocDAO().GetByID(lopHoc.ID);
            ViewBag.lophoc = lh;
            IEnumerable<TaiLieu> audiolist = null;
            if (lh.TaiLieux.Count() > 0) { audiolist = lh.TaiLieux.Where(x => x.idLH==lh.ID && x.idKN == idkn); }
            ViewBag.idkn = idkn;
            return View(audiolist);
        }
        [HttpPost]
        public ActionResult Tailieu(HttpPostedFileBase file, int idlh,int idkn)
        {
            //try
            //
            if (file.ContentLength > 0)
            {
                var lh = new LopHocDAO().GetByID(idlh);
                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/Content/img/"), _FileName);
                file.SaveAs(_path);
                int fileSize = file.ContentLength;
                int Size = fileSize / 1000000;
                var dao = new TaiLieuDAO();
                var tailieu = new TaiLieu();
                tailieu.ten = _FileName;
                tailieu.FileSize = Size;
                tailieu.link = _path;
                tailieu.idLH = lh.ID;
                tailieu.thoiGian = DateTime.Now;
                tailieu.idTK = lh.Giangvien.TaiKhoan.iD;
                tailieu.idKN = idkn;
                dao.Insert(tailieu);
            }
            ViewBag.Message = "File Uploaded Successfully!!";
            return RedirectToAction("Index/" + idlh, "QLLopHoc");
            //}
            //catch
            //{
            //    ViewBag.Message = "File upload failed!!";
            //    return RedirectToAction("File");
            //}
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var dao = new TaiLieuDAO();
            var model = dao.GetByID(ID);
            return PartialView("Edit", model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(TaiLieu tl)
        {
            var dao = new TaiLieuDAO();
            var tailieu = dao.GetByID(tl.ID);
            if (ModelState.IsValid)
            {
                tailieu.link = tl.link;
                bool kt = dao.Update(tailieu);
                if (kt)
                {
                    TempData["testmsg"] = "Cập nhât thành công.";
                    return RedirectToAction("Viet/" + tailieu.LopHoc.ID, "Viet");
                }
                else
                {
                    TempData["testmsg"] = "Cập nhât không thành công.";
                }
            }        
            return RedirectToAction("Index/" + tailieu.LopHoc.ID+ "#custom-tabs-four-onlineclasss", "QLLopHoc");
        }
       
        [HttpGet]
        public ActionResult Baitap(LopHoc lopHoc, int idkn)
        {
            var lh = new LopHocDAO().GetByID(lopHoc.ID);
            ViewBag.lophoc = lh;
            ViewBag.idkn = idkn;
            IEnumerable<TaiLieu> audiolist = null;
            if (lh.TaiLieux.Count() > 0) { audiolist = lh.TaiLieux.Where(x => x.TaiKhoan.tenDangNhap == User.Identity.Name && x.idKN == idkn); }
            return View(audiolist);
        }
        //Tạo phương thức hành động UploadAudio với [HttpPost] trong bộ điều khiển. 
        //Viết đoạn mã sau để chèn dữ liệu vào cơ sở dữ liệu và tải tệp lên trong thư mục AudioFileUpload của dự án.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Baitap(string ten, string link, int idlh, int idkn)
        {
            var lh = new LopHocDAO().GetByID(idlh);
            var dao = new TaiLieuDAO();
            var tailieu = new TaiLieu();
            tailieu.ten = ten;
            tailieu.link = link;
            tailieu.idLH = lh.ID;
            tailieu.idTK = lh.Giangvien.TaiKhoan.iD;
            tailieu.idKN = idkn;
            tailieu.thoiGian = DateTime.Now;
            dao.Insert(tailieu);
            return RedirectToAction("Index/" + lh.ID, "QLLopHoc");
        }
    }
}