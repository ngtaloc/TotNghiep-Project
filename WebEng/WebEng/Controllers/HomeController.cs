using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Controllers
{
    public class HomeController : LayoutController
    {
        [HttpGet]
        public ActionResult Index()
        {
            //update data            
            var dao = new LopHocDAO();
            dao.upload();
            var model = dao.FindAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string tim)
        {
            //update data            
            var dao = new LopHocDAO();
            dao.upload();
            var model = dao.TimLopHoc(tim);
            return View(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }   

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ChiTiet(int id)
        {
            var dao = new LopHocDAO();
            var model = dao.GetByID(id);
            TimeSpan Time = model.ngayEnd.Value - model.ngayBegin.Value;
            TempData["Sothang"] = (float.Parse(Time.Days.ToString()) / 30).ToString("#");
            //ViewBag.hocvien = new HocVienDAO().FindByTDN(User.Identity.Name);
            return View(model);
        }
        [HttpPost]
        public ActionResult binhluan(int id)
        {           
            TempData["testmsg"] = "bình luận!";
            return RedirectToAction("chitiet/" + id, "Home");          
        }

        public ActionResult InfoGV(int id)
        {
            var model = new GiangVienDAO().GetByID(id);
            decimal danhgiaTong = 0;
            decimal danhgiaSo = 0;
            decimal dg1 = 0;
            decimal dg2 = 0;
            decimal dg3 = 0;
            decimal dg4 = 0;
            decimal dg5 = 0;
            List<int> danhgia = new List<int>();
            foreach (var item in model.LopHocs)
            {
                foreach (var it in item.DSLopHocs)
                {
                    if (!String.IsNullOrEmpty(it.danhgia.ToString()) && it.danhgia.Value != 0)
                    {
                        danhgiaSo++;
                        int dg = int.Parse(it.danhgia.ToString());
                        danhgiaTong += dg;
                        switch (dg)
                        {
                            case 1:
                                {
                                    dg1++;
                                    break;
                                }
                            case 2:
                                {
                                    dg2++;
                                    break;
                                }
                            case 3:
                                {
                                    dg3++;
                                    break;
                                }
                            case 4:
                                {
                                    dg4++;
                                    break;
                                }
                            case 5:
                                {
                                    dg5++;
                                    break;
                                }
                        }
                    }

                }
            }
            danhgia.Add(Convert.ToInt32(decimal.Round(dg1 / danhgiaSo, 2) * 100));
            danhgia.Add(Convert.ToInt32(dg1));
            danhgia.Add(Convert.ToInt32(decimal.Round(dg2 / danhgiaSo, 2) * 100));
            danhgia.Add(Convert.ToInt32(dg2));
            danhgia.Add(Convert.ToInt32(decimal.Round(dg3 / danhgiaSo, 2) * 100));
            danhgia.Add(Convert.ToInt32(dg3));
            danhgia.Add(Convert.ToInt32(decimal.Round(dg4 / danhgiaSo, 2) * 100));
            danhgia.Add(Convert.ToInt32(dg4));
            danhgia.Add(Convert.ToInt32(decimal.Round(dg5 / danhgiaSo, 2) * 100));
            danhgia.Add(Convert.ToInt32(dg5));
            ViewBag.TrungBinh = decimal.Round(danhgiaTong / danhgiaSo, 2);
            ViewBag.SoDG = danhgiaSo;
            ViewBag.ListDG = danhgia;
            return View(model);
        }
    }
}