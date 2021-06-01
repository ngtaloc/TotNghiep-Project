using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Models.Framework;
using Models.DAO;

namespace WebEng.Areas.GiaoVien.Controllers
{

    public class NgheController : Controller
    {
        // GET: GiaoVien/Nghe
        public ActionResult Index()
        {
            return View();
        }
        //Tạo phương thức hành động UploadAudio với [HttpGet] trong bộ điều khiển.
        //Viết đoạn mã sau để lấy dữ liệu từ bảng cơ sở dữ liệu.
        [HttpGet]
        public ActionResult UploadAudio(int id = 1)
        {
            var lh = new LopHocDAO().GetByID(id);   
            ViewBag.lophoc = lh;
            IEnumerable<TaiLieu> audiolist = null;
            if (lh.TaiLieux.Count() > 0) { audiolist = lh.TaiLieux.Where(x => x.TaiKhoan.tenDangNhap == User.Identity.Name && x.idKN == 1); }
            return View(audiolist);
        }
        //Tạo phương thức hành động UploadAudio với [HttpPost] trong bộ điều khiển. 
        //Viết đoạn mã sau để chèn dữ liệu vào cơ sở dữ liệu và tải tệp lên trong thư mục AudioFileUpload của dự án.
        [HttpPost]
        public ActionResult UploadAudio(HttpPostedFileBase fileupload, int idlh)
        {
            if (fileupload != null)
            {
                var lh = new LopHocDAO().GetByID(idlh);
                string fileName = Path.GetFileName(fileupload.FileName);
                int fileSize = fileupload.ContentLength;
                int Size = fileSize / 1000000;
                fileupload.SaveAs(Server.MapPath("~/" + fileName));
                var dao = new TaiLieuDAO();
                var tailieu = new TaiLieu();
                tailieu.ten = fileName;
                tailieu.FileSize = Size;
                tailieu.link = "~/" + fileName;
                tailieu.idLH = lh.ID;
                tailieu.idTK = lh.Giangvien.TaiKhoan.iD;
                tailieu.idKN = 1;            
                dao.Insert(tailieu);
            }
            return RedirectToAction("UploadAudio");
        }
    }
}