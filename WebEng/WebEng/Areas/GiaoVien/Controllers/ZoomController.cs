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
            var zc = new NgayDAO().FindByLopHoc(id);
            ViewBag.Zoom = zc;
            var lh = new LopHocDAO().GetByID(id);
            ViewBag.lophoc = lh;

            IEnumerable<TaiLieu> audiolist = null;
            if (lh.TaiLieux.Count() > 0) { audiolist = lh.TaiLieux.Where(x => x.TaiKhoan.tenDangNhap == User.Identity.Name && x.idKN == null); }
            return View(audiolist);
        }
        //Tạo phương thức hành động UploadAudio với [HttpPost] trong bộ điều khiển. 
        //Viết đoạn mã sau để chèn dữ liệu vào cơ sở dữ liệu và tải tệp lên trong thư mục AudioFileUpload của dự án.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Zoom(string ten, string trangthai,string ma, int idlh, string thoigian)
        {
            var lh = new LopHocDAO().GetByID(idlh);
            var dao = new TaiLieuDAO();
            var tailieu = new TaiLieu();
            tailieu.ten = ten;
            tailieu.link = ma;
            tailieu.moTa = trangthai;
            tailieu.idLH = lh.ID;
            tailieu.idTK = lh.Giangvien.TaiKhoan.iD;
            //tailieu.idKN = 6;
            try
            {
                tailieu.thoiGian = DateTime.Parse(thoigian);
                dao.Insert(tailieu);
                TempData["testmsg"] = "Tạo phòng ZOOM thành công.";
            }
            catch (Exception ex)
            {
                TempData["testmsg"] = "Lỗi tạo phòng ZOOM: "+ex.Message;
            }
            
            return RedirectToAction("ChiTiet/" + lh.ID , "QLLopHoc");
        }
        //[HttpGet]
        //public ActionResult Ngay(int id, int idLH, string date, string thu)
        //{
        //    var lh = new NgayDAO().GetByID(id);
        //    ViewBag.lophoc = lh;
        //    IEnumerable<Ngay> audiolist1 = null;
        //    var ngay = new Ngay();
        //    ngay.iDLopHoc = idLH;
        //    ngay.ngay27 = date;

        //    return View(audiolist1);
        //}
    }
}