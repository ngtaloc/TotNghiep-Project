using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.GiaoVien.Controllers
{
    public class InfoController : Controller
    {
        // GET: GiaoVien/Info
        [Authorize(Roles = "GiaoVien")]
        public ActionResult Index()
        {
            var dao = new GiangVienDAO();
            var model = dao.FindByTDN(User.Identity.Name);
            return View(model);
        }
       
    }
}