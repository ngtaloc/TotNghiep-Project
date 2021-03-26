using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebEng.Areas.Admin.Models;


namespace WebEng.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            //bool rec = new AccountModel().login(model.userName, model.passWord);
            if (Membership.ValidateUser(model.userName,model.passWord) && ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.userName, model.rememberMe);
                RedirectToAction("Index", "Homes");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai!");
            }
            return View(model);
        }
    }
}