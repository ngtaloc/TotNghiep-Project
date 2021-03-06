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
    public class DocController : Controller
    {
        // GET: GiaoVien/Doc
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Doc(int id = 1)
        {
            var lh = new LopHocDAO().GetByID(id);
            ViewBag.lophoc = lh;
            
            IEnumerable<TaiLieu> audiolist = null;
            if (lh.TaiLieux.Count() > 0) { audiolist = lh.TaiLieux.Where(x => x.TaiKhoan.tenDangNhap == User.Identity.Name && x.idKN == 3); }
            return View(audiolist);
        }
        //Tạo phương thức hành động UploadAudio với [HttpPost] trong bộ điều khiển. 
        //Viết đoạn mã sau để chèn dữ liệu vào cơ sở dữ liệu và tải tệp lên trong thư mục AudioFileUpload của dự án.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Doc(string ten,string link, int idlh)
        {           
            var lh = new LopHocDAO().GetByID(idlh);
            var dao = new TaiLieuDAO();
            var tailieu = new TaiLieu();
            tailieu.ten = ten;
            tailieu.link = link;
            tailieu.idLH = lh.ID;
            tailieu.idTK = lh.Giangvien.TaiKhoan.iD;
            tailieu.idKN = 3;
            tailieu.thoiGian = DateTime.Now;
            dao.Insert(tailieu);
            return RedirectToAction("Doc/" + lh.ID, "Doc");
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
                    return RedirectToAction("Doc/" + tailieu.LopHoc.ID, "Doc");
                }
                else
                {
                    TempData["testmsg"] = "Cập nhât không thành công.";
                }
            }
            return RedirectToAction("Doc/" + tailieu.LopHoc.ID, "Doc");
        }
    }
}