using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using Models.DAO;
namespace WebEng.Areas.GiaoVien.Controllers
{
    public class ZoomController : Controller
    {
        // GET: GiaoVien/Zoom
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Zoom(int id = 1)
        {
            var lh = new LopHocDAO().GetByID(id);
            ViewBag.lophoc = lh;

            IEnumerable<TaiLieu> audiolist = null;
            if (lh.TaiLieux.Count() > 0) { audiolist = lh.TaiLieux.Where(x => x.TaiKhoan.tenDangNhap == User.Identity.Name && x.idKN == 6); }
            return View(audiolist);
        }
        //Tạo phương thức hành động UploadAudio với [HttpPost] trong bộ điều khiển. 
        //Viết đoạn mã sau để chèn dữ liệu vào cơ sở dữ liệu và tải tệp lên trong thư mục AudioFileUpload của dự án.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Zoom(string ten, string trangthai,string ma, int idlh)
        {
            var lh = new LopHocDAO().GetByID(idlh);
            var dao = new TaiLieuDAO();
            var tailieu = new TaiLieu();
            tailieu.ten = ten;
            tailieu.link = ma;
            tailieu.moTa = trangthai;
            tailieu.idLH = lh.ID;
            tailieu.idTK = lh.Giangvien.TaiKhoan.iD;
            tailieu.idKN = 6;
            tailieu.thoiGian = DateTime.Now;
            dao.Insert(tailieu);
            return RedirectToAction("Zoom/" + lh.ID, "Zoom");
        }
    }
}