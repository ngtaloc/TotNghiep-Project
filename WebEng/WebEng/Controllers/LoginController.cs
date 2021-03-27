using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEng.Common;
using WebEng.Models;

namespace WebEng.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                var kt = dao.Login(model.userName, EncryptorMD5.MD5Hash(model.passWord));
                if (kt == 1)
                {
                    var user = dao.GetByTDN(model.userName);
                    var userSession = new TaiKhoanLogin();
                    userSession.userName = user.tenDangNhap;
                    userSession.iDTaiKhoan = user.iD;
                    userSession.quyen = user.idNQ;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    if(user.idNQ == 1)
                    {
                        return RedirectToAction("Index", "Admin");
                    }else if (user.idNQ == 2)
                    {
                        return RedirectToAction("Index", "GiangVien");
                    }
                    else if(user.idNQ == 3)
                    {
                        return RedirectToAction("Index", "HocVien");
                    }
                    

                }
                else if (kt == 0)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn đã bị khóa!");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai!");
                }
            }
            return View("Index");
        }
    }
}