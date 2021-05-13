using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;

namespace WebEng.Areas.GiaoVien.Controllers
{
    [Authorize(Roles = "GiaoVien")]
    public class HocController : Controller
    {
        // GET: GiaoVien/Hoc
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UploadFile()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
             if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/"), _FileName);
                    file.SaveAs(_path);
                ViewBag.Message = "Tải file thành công!!";
                return View("Index");
            }       
             else
            {
                ViewBag.Message = "Thất bại!";
                return View("Index");
            }
        }
    }
}