using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEng.Common;

namespace WebEng.Controllers
{
    public class DangKyController : Controller
    {
        // GET: DangKy
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DKHocVien()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DKHocVien(HocVien hocVien,TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                var daoHV = new HocVienDAO();
                var daoTK = new TaiKhoanDAO();
                int idtk = daoTK.Insert(taiKhoan);
                int idhv = daoHV.Insert(hocVien);
                if (idhv > 0)
                {
                    ModelState.AddModelError("", "Đăng ký học viên thành công");
                }
                else
                {
                    return RedirectToAction("DKHocVien", "DangKy");
        
                }
            }
            return View("DKHocVien");
        }

        [HttpGet]
        public ActionResult DKTaiKhoan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DKTaiKhoan(TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
               
                var daoTK = new TaiKhoanDAO();
                var md5pass = EncryptorMD5.MD5Hash(taiKhoan.matKhau);
                taiKhoan.matKhau = md5pass;
                //taiKhoan.idNQ = 1;
                int idtk = daoTK.Insert(taiKhoan);
              
                if (idtk > 0)
                {
                    ModelState.AddModelError("", "Đăng ký tài khoản thành công");
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    return RedirectToAction("Index", "DangKy");

                }
            }
            return View("DKHocVien");
        }

    }
}