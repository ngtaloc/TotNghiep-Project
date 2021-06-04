using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using Models.DAO;
using System.IO;

namespace WebEng.Areas.GiaoVien.Controllers
{
    public class NoiController : Controller
    {
        // GET: GiaoVien/Noi
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Noi(int id = 1)
        {
            var lh = new LopHocDAO().GetByID(id);
            ViewBag.lophoc = lh;
            IEnumerable<TaiLieu> audiolist = null;
            if (lh.TaiLieux.Count() > 0) { audiolist = lh.TaiLieux.Where(x => x.TaiKhoan.tenDangNhap == User.Identity.Name && x.idKN == 2); }
            return View(audiolist);
        }
        //Tạo phương thức hành động UploadAudio với [HttpPost] trong bộ điều khiển. 
        //Viết đoạn mã sau để chèn dữ liệu vào cơ sở dữ liệu và tải tệp lên trong thư mục AudioFileUpload của dự án.
        [HttpPost]
        public ActionResult Noi(HttpPostedFileBase file, int idlh)
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
                tailieu.idKN = 2;
                dao.Insert(tailieu);
            }
            ViewBag.Message = "File Uploaded Successfully!!";
            return RedirectToAction("Noi");
        }
    }
}