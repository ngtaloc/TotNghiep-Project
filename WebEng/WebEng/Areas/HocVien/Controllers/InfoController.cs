using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using WebEng.Common;

namespace WebEng.Areas.HocVien.Controllers
{
    [Authorize(Roles = "HocVien")]
    public class InfoController : Controller
    {
        // GET: HocVien/Info
        
        public ActionResult Index()
        {
            var dao = new HocVienDAO();
            global::Models.Framework.HocVien model = dao.FindByTDN(User.Identity.Name);
            
            return View(model);
        }
        
        public ActionResult Edit(global::Models.Framework.HocVien hv)
        {
            var dao = new HocVienDAO();
           
            try
            {
                dao.Update(hv,User.Identity.Name);
                TempData["testmsg"] = " Cập nhật thành công ";

                return RedirectToAction("Index", "Info");
            }
            catch (Exception e)
            {
                TempData["testmsg"] = "Có lỗi trong quá trình cập nhật: " + e.Message.ToString();

            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult DoiMK(int ID)
        {
            var model = new TaiKhoanDAO().FindByID(ID);
            return PartialView("DoiMK", model);
        }
        [HttpPost]
        public ActionResult DoiMK(TaiKhoan tk,string matkhau,string matkhaumoi)
        {
           if (tk.matKhau == matkhaumoi)
            {
                tk.matKhau = EncryptorMD5.MD5Hash(matkhaumoi);                            
                var doi = new TaiKhoanDAO().DoiMK(tk);
                if (doi)
                {
                    TempData["testmsg"] = "Đổi mật khẩu thành công.";
                }
                else
                {
                    TempData["testmsg"] = "Có lỗi trong quá trình Đổi mật khẩu. Vui lòng thử lại sau.";
                }
            }
            else
            {
                TempData["testmsg"] = "Mật khẩu cũ không đúng.";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}