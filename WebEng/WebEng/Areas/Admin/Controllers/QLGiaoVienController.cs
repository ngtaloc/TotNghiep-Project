﻿using Models.DAO;
using Models.Framework;
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

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var dao = new GiangVienDAO();
            var model = dao.GetByID(ID);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Giangvien giangvien)
        {
            if (ModelState.IsValid)
            {
                var dao = new GiangVienDAO();
                bool kt = dao.Update(giangvien);
                if (kt)
                {
                    ModelState.AddModelError("", "Cập nhât thành công");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhât không thành công");
                }
            }
            return View("Index");
        }
    }
}