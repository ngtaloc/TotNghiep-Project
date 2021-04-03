using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.Admin.Controllers
{
    public class QLGiaoVienController : Controller
    {
        // GET: Admin/QLGiaoVien
        public ActionResult Index(int page = 1, int pageSize = 1)
        {
            var dao = new GiangVienDAO();
            var model = dao.listAllPageList(page, pageSize);
            
            return View(model);
        }
    }
}