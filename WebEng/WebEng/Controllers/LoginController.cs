using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                if (Membership.ValidateUser(model.userName, EncryptorMD5.MD5Hash(model.passWord)))
                {
                    //var kt = dao.Login(model.userName, EncryptorMD5.MD5Hash(model.passWord));
                    var user = dao.GetByTDN(model.userName);
                    if(user.trangThai == 0)
                    {
                        
                        ModelState.AddModelError("", "Tài khoản của bạn đã bị khóa!");
                    }
                    else
                    {
                        if (Roles.IsUserInRole(model.userName, "Admin"))
                        {
                            FormsAuthentication.SetAuthCookie(model.userName, model.rememberMe);
                            return RedirectToAction("Index", "Layout");
                        }
                        else
                        if(Roles.IsUserInRole(model.userName, "GiaoVien"))
                        {
                            FormsAuthentication.SetAuthCookie(model.userName, model.rememberMe);
                            return RedirectToAction("gv", "Layout");
                        }
                        else
                        {
                            FormsAuthentication.SetAuthCookie(model.userName, model.rememberMe);
                            return RedirectToAction("Index", "Home");
                        }
                            
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai!");
                }
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}