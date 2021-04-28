using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.GiaoVien.Controllers
{
    [Authorize(Roles = "GiaoVien")]
    public class GiaoVienController : Controller
    {
        // GET: GiaoVien/GiaoVien
        public ActionResult GiaoVien()
        {
            var dao = new LopHocDAO();
            var model = dao.FindLopHocGiaoVien(User.Identity.Name);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new LopHoc();
            return PartialView("Create", model);
        }

        [HttpPost]
        public ActionResult Create(LopHoc lophoc, bool Listening=false, bool Speaking = false, bool Reading = false, bool Writing = false, string lvListening=null, string lvSpeaking = null, string lvReading = null, string lvWriting = null)
        {
            if (ModelState.IsValid)
            {
                var dao = new LopHocDAO();
                lophoc.idGV = new GiangVienDAO().FindByTDN(User.Identity.Name).ID;
                if (Listening)
                {
                    var knlh = new KyNangLopHoc();
                    knlh.LopHoc = lophoc;
                    knlh.idKN = 1;
                    knlh.idCD = int.Parse(lvListening);
                    lophoc.KyNangLopHocs.Add(knlh);
                }
                if (Speaking)
                {
                    var knlh = new KyNangLopHoc();
                    knlh.LopHoc = lophoc;
                    knlh.idKN = 2;
                    knlh.idCD = int.Parse(lvSpeaking);
                    lophoc.KyNangLopHocs.Add(knlh);
                }
                if (Reading)
                {
                    var knlh = new KyNangLopHoc();
                    knlh.LopHoc = lophoc;
                    knlh.idKN = 3;
                    knlh.idCD = int.Parse(lvReading);
                    lophoc.KyNangLopHocs.Add(knlh);
                }
                if (Writing)
                {
                    var knlh = new KyNangLopHoc();
                    knlh.LopHoc = lophoc;
                    knlh.idKN = 4;
                    knlh.idCD = int.Parse(lvWriting);
                    lophoc.KyNangLopHocs.Add(knlh);
                }
                
                try {
                    dao.Insert(lophoc);
                    ModelState.AddModelError("", "Tạo lớp thành công");
                    return RedirectToAction("");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", "Tạo lớp không thành công: "+e.ToString());
                }
               
            }
            return View();
        }
    }
}