using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebEng.Areas.HocVien.Controllers
{
    public class InfoController : Controller
    {
        // GET: HocVien/Info
        public ActionResult Index()
        {
            var dao = new HocVienDAO();
            var model = dao.FindByTDN(User.Identity.Name);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(HocVien hocVien)
        {
            return View();
        }
    }
}