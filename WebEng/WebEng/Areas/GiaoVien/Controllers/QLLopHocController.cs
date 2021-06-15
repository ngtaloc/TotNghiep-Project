using HtmlAgilityPack;
using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.GiaoVien.Controllers
{
    [Authorize(Roles = "GiaoVien")]
    public class QLLopHocController : Controller
    {
        // GET: GiaoVien/QLLopHoc
        public ActionResult Index()
        {
            var dao = new LopHocDAO();
            var model = dao.FindLopHocGiaoVien(User.Identity.Name);
            return View(model);
        }
        public ActionResult Tim(string tim)
        {
            int tt = -1;
            try
            {
                tt = int.Parse(tim);
            }
            catch { }
            var dao = new LopHocDAO();
            var model = dao.FindLopHocTim(User.Identity.Name, tim, tt);
            foreach (var item in model)
            {

            }
            return View("Index",model);
        }
        public ActionResult ChiTiet(int id)
        {
            var model = new LopHocDAO().GetByID(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new LopHoc();
            return PartialView("Create", model);
        }

        [HttpPost]
        public ActionResult Create(LopHoc lophoc, bool Listening = false, bool Speaking = false, bool Reading = false, bool Writing = false, string lvListening = null, string lvSpeaking = null, string lvReading = null, string lvWriting = null, int sothang = 0,
            bool t2 = false, bool t3 = false, bool t4 = false, bool t5 = false, bool t6 = false, bool t7 = false, bool cn = false,
            string bt2 = null, string et2 = null, string bt3 = null, string et3 = null, string bt4 = null, string et4 = null, string bt5 = null, string et5 = null, string bt6 = null, string et6 = null, string bt7 = null, string et7 = null, string bcn = null, string ecn = null)
        {

            var gv = new GiangVienDAO().FindByTDN(User.Identity.Name);
            if (ModelState.IsValid)
            {
                var NgayB = lophoc.ngayBegin.Value;
                var n = new Ngay();
                n.iDLopHoc = lophoc.ID;
                n.iDThang = lophoc.ngayBegin.Value.Month;
                n.nam = lophoc.ngayBegin.Value.Year.ToString();
                //1-27-4-2021-13-00-15-00
                int buoi = 0;
                while (DateTime.Compare(NgayB, lophoc.ngayEnd.Value) <= 0)
                {
                    int thu = (int)(NgayB.DayOfWeek) + 1;
                    switch (thu)
                    {
                        case 2:
                            if (t2)
                            {
                                if (DateTime.Compare(DateTime.Parse(bt2), DateTime.Parse(et2)) >= 0)
                                {
                                    TempData["testmsg"] = "Lỗi giờ bắt đầu lớn hơn giờ kết thúc tại thứ 2.";
                                    return RedirectToAction("Index", "QLLopHoc");
                                }
                                switch (NgayB.Day)
                                {
                                    case 1: n.ngay1 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 2: n.ngay2 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 3: n.ngay3 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 4: n.ngay4 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 5: n.ngay5 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 6: n.ngay6 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 7: n.ngay7 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 8: n.ngay8 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 9: n.ngay9 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 10: n.ngay10 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 11: n.ngay11 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 12: n.ngay12 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 13: n.ngay13 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 14: n.ngay15 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 15: n.ngay15 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 16: n.ngay16 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 17: n.ngay17 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 18: n.ngay18 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 19: n.ngay19 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 20: n.ngay20 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 21: n.ngay21 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 22: n.ngay22 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 23: n.ngay23 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 24: n.ngay24 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 25: n.ngay25 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 26: n.ngay26 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 27: n.ngay27 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 28: n.ngay28 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 29: n.ngay29 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 30: n.ngay30 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                    case 31: n.ngay31 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt2.Replace(":", "-") + "-" + et2.Replace(":", "-"); buoi++; break;
                                }
                                n.thu2 = bt2.Replace(":", "-") + "-" + et2.Replace(":", "-");
                            }
                            break;
                        case 3:
                            if (t3)
                            {
                                if (DateTime.Compare(DateTime.Parse(bt3), DateTime.Parse(et3)) >= 0)
                                {
                                    TempData["testmsg"] = "Lỗi giờ bắt đầu lớn hơn giờ kết thúc tại thứ 3.";
                                    return RedirectToAction("Index", "QLLopHoc");
                                }
                                switch (NgayB.Day)
                                {
                                    case 1: n.ngay1 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 2: n.ngay2 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 3: n.ngay3 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 4: n.ngay4 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 5: n.ngay5 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 6: n.ngay6 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 7: n.ngay7 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 8: n.ngay8 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 9: n.ngay9 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 10: n.ngay10 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 11: n.ngay11 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 12: n.ngay12 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 13: n.ngay13 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 14: n.ngay15 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 15: n.ngay15 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 16: n.ngay16 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 17: n.ngay17 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 18: n.ngay18 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 19: n.ngay19 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 20: n.ngay20 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 21: n.ngay21 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 22: n.ngay22 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 23: n.ngay23 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 24: n.ngay24 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 25: n.ngay25 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 26: n.ngay26 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 27: n.ngay27 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 28: n.ngay28 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 29: n.ngay29 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 30: n.ngay30 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                    case 31: n.ngay31 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt3.Replace(":", "-") + "-" + et3.Replace(":", "-"); buoi++; break;
                                }
                                n.thu3 = bt3.Replace(":", "-") + "-" + et3.Replace(":", "-");
                            }
                            break;
                        case 4:
                            if (t4)
                            {
                                if (DateTime.Compare(DateTime.Parse(bt4), DateTime.Parse(et4)) >= 0)
                                {
                                    TempData["testmsg"] = "Lỗi giờ bắt đầu lớn hơn giờ kết thúc tại thứ 4.";
                                    return RedirectToAction("Index", "QLLopHoc");
                                }
                                switch (NgayB.Day)
                                {
                                    case 1: n.ngay1 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 2: n.ngay2 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 3: n.ngay3 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 4: n.ngay4 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 5: n.ngay5 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 6: n.ngay6 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 7: n.ngay7 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 8: n.ngay8 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 9: n.ngay9 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 10: n.ngay10 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 11: n.ngay11 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 12: n.ngay12 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 13: n.ngay13 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 14: n.ngay15 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 15: n.ngay15 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 16: n.ngay16 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 17: n.ngay17 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 18: n.ngay18 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 19: n.ngay19 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 20: n.ngay20 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 21: n.ngay21 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 22: n.ngay22 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 23: n.ngay23 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 24: n.ngay24 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 25: n.ngay25 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 26: n.ngay26 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 27: n.ngay27 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 28: n.ngay28 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 29: n.ngay29 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 30: n.ngay30 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                    case 31: n.ngay31 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt4.Replace(":", "-") + "-" + et4.Replace(":", "-"); buoi++; break;
                                }
                                n.thu4 = bt4.Replace(":", "-") + "-" + et4.Replace(":", "-");
                            }
                            break;
                        case 5:
                            if (t5)
                            {
                                if (DateTime.Compare(DateTime.Parse(bt5), DateTime.Parse(et5)) >= 0)
                                {
                                    TempData["testmsg"] = "Lỗi giờ bắt đầu lớn hơn giờ kết thúc tại thứ 5.";
                                    return RedirectToAction("Index", "QLLopHoc");
                                }
                                switch (NgayB.Day)
                                {
                                    case 1: n.ngay1 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 2: n.ngay2 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 3: n.ngay3 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 4: n.ngay4 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 5: n.ngay5 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 6: n.ngay6 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 7: n.ngay7 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 8: n.ngay8 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 9: n.ngay9 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 10: n.ngay10 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 11: n.ngay11 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 12: n.ngay12 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 13: n.ngay13 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 14: n.ngay15 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 15: n.ngay15 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 16: n.ngay16 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 17: n.ngay17 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; buoi++; break;
                                    case 18: n.ngay18 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; break;
                                    case 19: n.ngay19 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; break;
                                    case 20: n.ngay20 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; break;
                                    case 21: n.ngay21 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; break;
                                    case 22: n.ngay22 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; break;
                                    case 23: n.ngay23 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; break;
                                    case 24: n.ngay24 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; break;
                                    case 25: n.ngay25 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; break;
                                    case 26: n.ngay26 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; break;
                                    case 27: n.ngay27 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; break;
                                    case 28: n.ngay28 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; break;
                                    case 29: n.ngay29 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; break;
                                    case 30: n.ngay30 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; break;
                                    case 31: n.ngay31 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt5.Replace(":", "-") + "-" + et5.Replace(":", "-"); buoi++; break;
                                }
                                n.thu5 = bt5.Replace(":", "-") + "-" + et5.Replace(":", "-");
                            }
                            break;
                        case 6:
                            if (t6)
                            {
                                if (DateTime.Compare(DateTime.Parse(bt6), DateTime.Parse(et6)) >= 0)
                                {
                                    TempData["testmsg"] = "Lỗi giờ bắt đầu lớn hơn giờ kết thúc tại thứ 6.";
                                    return RedirectToAction("Index", "QLLopHoc");
                                }
                                switch (NgayB.Day)
                                {
                                    case 1: n.ngay1 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 2: n.ngay2 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 3: n.ngay3 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 4: n.ngay4 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 5: n.ngay5 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 6: n.ngay6 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 7: n.ngay7 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 8: n.ngay8 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 9: n.ngay9 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 10: n.ngay10 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 11: n.ngay11 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 12: n.ngay12 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 13: n.ngay13 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 14: n.ngay15 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 15: n.ngay15 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 16: n.ngay16 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 17: n.ngay17 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 18: n.ngay18 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 19: n.ngay19 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 20: n.ngay20 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 21: n.ngay21 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 22: n.ngay22 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 23: n.ngay23 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 24: n.ngay24 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 25: n.ngay25 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 26: n.ngay26 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 27: n.ngay27 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 28: n.ngay28 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 29: n.ngay29 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 30: n.ngay30 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                    case 31: n.ngay31 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt6.Replace(":", "-") + "-" + et6.Replace(":", "-"); buoi++; break;
                                }
                                n.thu6 = bt6.Replace(":", "-") + "-" + et6.Replace(":", "-");
                            }
                            break;
                        case 7:
                            if (t7)
                            {
                                if (DateTime.Compare(DateTime.Parse(bt7), DateTime.Parse(et7)) >= 0)
                                {
                                    TempData["testmsg"] = "Lỗi giờ bắt đầu lớn hơn giờ kết thúc tại thứ 7.";
                                    return RedirectToAction("Index", "QLLopHoc");
                                }
                                switch (NgayB.Day)
                                {
                                    case 1: n.ngay1 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 2: n.ngay2 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 3: n.ngay3 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 4: n.ngay4 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 5: n.ngay5 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 6: n.ngay6 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 7: n.ngay7 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 8: n.ngay8 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 9: n.ngay9 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 10: n.ngay10 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 11: n.ngay11 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 12: n.ngay12 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 13: n.ngay13 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 14: n.ngay15 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 15: n.ngay15 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 16: n.ngay16 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 17: n.ngay17 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 18: n.ngay18 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 19: n.ngay19 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 20: n.ngay20 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 21: n.ngay21 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 22: n.ngay22 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 23: n.ngay23 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 24: n.ngay24 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 25: n.ngay25 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 26: n.ngay26 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 27: n.ngay27 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 28: n.ngay28 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 29: n.ngay29 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 30: n.ngay30 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                    case 31: n.ngay31 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bt7.Replace(":", "-") + "-" + et7.Replace(":", "-"); buoi++; break;
                                }
                                n.thu7 = bt7.Replace(":", "-") + "-" + et7.Replace(":", "-");
                            }
                            break;
                        case 1:
                            if (cn)
                            {
                                if (DateTime.Compare(DateTime.Parse(bcn), DateTime.Parse(ecn)) >= 0)
                                {
                                    TempData["testmsg"] = "Lỗi giờ bắt đầu lớn hơn giờ kết thúc tại chủ nhật.";
                                    return RedirectToAction("Index", "QLLopHoc");
                                }
                                switch (NgayB.Day)
                                {
                                    case 1: n.ngay1 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 2: n.ngay2 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 3: n.ngay3 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 4: n.ngay4 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 5: n.ngay5 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 6: n.ngay6 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 7: n.ngay7 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 8: n.ngay8 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 9: n.ngay9 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 10: n.ngay10 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 11: n.ngay11 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 12: n.ngay12 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 13: n.ngay13 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 14: n.ngay15 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 15: n.ngay15 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 16: n.ngay16 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 17: n.ngay17 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 18: n.ngay18 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 19: n.ngay19 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 20: n.ngay20 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 21: n.ngay21 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 22: n.ngay22 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 23: n.ngay23 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 24: n.ngay24 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 25: n.ngay25 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 26: n.ngay26 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 27: n.ngay27 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 28: n.ngay28 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 29: n.ngay29 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 30: n.ngay30 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                    case 31: n.ngay31 = lophoc.ID.ToString() + "-" + NgayB.ToString().Split(' ')[0].Replace("/", "-") + "-" + bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-"); buoi++; break;
                                }
                                n.chunhat = bcn.Replace(":", "-") + "-" + ecn.Replace(":", "-");
                            }
                            break;
                    }
                    NgayB = NgayB.AddDays(1);
                    if (NgayB.Day == 1 || DateTime.Compare(NgayB, lophoc.ngayEnd.Value) > 0)
                    {
                        lophoc.Ngays.Add(n);
                        n = new Ngay();
                        n.iDLopHoc = lophoc.ID;
                        n.iDThang = NgayB.Month;
                        n.nam = NgayB.Year.ToString();
                    }
                }
                var daoLH = new LopHocDAO();
                lophoc.idGV = gv.ID;
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

                try
                {
                    lophoc.trangThai = 0;   //--0:Đang tuyển sinh	1:Ngừng tuyển sinh	2:Đang học	3:Đã kết thúc
                    lophoc.soBuoi = buoi;
                    lophoc.ngayDangKy = DateTime.Now;
                    int idlh=daoLH.Insert(lophoc);
                    LichSuGD lsgd = new LichSuGD();
                    lsgd.idVT = gv.TaiKhoan.ViTiens.FirstOrDefault().iD;
                    lsgd.LoaiGD = 1;
                    lsgd.SoTienGD = 100000;
                    lsgd.TenGD = "Có tên " + lophoc.tenLopHoc + " và mã lớp LH" + lophoc.ID + " với giá 100.000 VNĐ";
                    lsgd.ThoiGiangGD = DateTime.Now;
                    int idgd = new LichSuGDDAO().Insert(lsgd);
                    ModelState.AddModelError("", "Tạo lớp thành công");
                    TempData["testmsg"] = "Tạo lớp thành công";
                    return RedirectToAction("ChiTiet/" + idlh, "QLLopHoc");
                    
                }
                catch (Exception e)
                {
                    TempData["testmsg"] = "Có lỗi trong quá trình tạo lớp: " + e.Message.ToString();
                    return RedirectToAction("Index", "QLLopHoc");
                }

            }
            else
            {
                TempData["testmsg"] = "Thông tin lớp không đúng định dạng.";
                return RedirectToAction("Index", "QLLopHoc");
            }

        }



        [HttpGet]
        public ActionResult InfoLH(LopHoc lopHoc)
        {
            return View(lopHoc);

        }
        [HttpPost]
        public ActionResult InfoLH(DSLopHoc ds)
        {
            var dao = new DSLopHocDAO();
            if(ds.trangthai == 1)
            {
                TempData["testmsg"] = "Xác nhận thành công.";
                ds.trangthai = 2;
            }
            else if(ds.trangthai == 2)
            {
                TempData["testmsg"] = "Khóa thành công.";
                ds.trangthai = 3;
            }
            else
            {
                TempData["testmsg"] = "Mở khóa thành công.";
                ds.trangthai = 1;
            }
            dao.UpdateStatus(ds);
            var lh = new LopHocDAO().GetByID(ds.idLH);
            return RedirectToAction("chitietlophoc/" + ds.idLH, "QLLopHoc");
        }
        public ActionResult Listening(LopHoc lopHoc)
        {
            return View(lopHoc);

        }
        public ActionResult Speaking(LopHoc lopHoc)
        {
            return View(lopHoc);

        }
        public ActionResult Reading(LopHoc lopHoc)
        {
            return View(lopHoc);

        }
        public ActionResult Writing(LopHoc lopHoc)
        {
            return View(lopHoc);

        }
        [ValidateInput(false)]
        public ActionResult OnlineClass(LopHoc lopHoc)
        {
            return View(lopHoc);

        }
        [HttpGet]
        public ActionResult Tailieu(LopHoc lopHoc, int idkn)
        {
            var lh = new LopHocDAO().GetByID(lopHoc.ID);
            ViewBag.lophoc = lh;
            IEnumerable<TaiLieu> audiolist = null;
            if (lh.TaiLieux.Count() > 0) { audiolist = lh.TaiLieux.Where(x => x.idLH==lh.ID && x.idKN == idkn && string.IsNullOrEmpty(x.idBT.ToString())); }
            ViewBag.idkn = idkn;
            return View(audiolist);
        }
        [HttpPost]
        public ActionResult Tailieu(HttpPostedFileBase file, int idlh,int idkn)
        {
            //try
            //
            if (file.ContentLength > 0)
            {
                var lh = new LopHocDAO().GetByID(idlh);
                string _FileName = Path.GetFileName(file.FileName);
                string path = "Content/Data/tailieu/lh" + idlh + "/kn" + idkn + "/";
                string _path = Path.Combine(Server.MapPath("~/"+path), _FileName);
                Directory.CreateDirectory(Path.Combine(Server.MapPath("~/"+path)));
                file.SaveAs(_path);
                int fileSize = file.ContentLength;
                int Size = fileSize / 1000000;
                var dao = new TaiLieuDAO();
                var tailieu = new TaiLieu();
                tailieu.ten = _FileName;
                tailieu.FileSize = Size;
                tailieu.link = path + _FileName;
                tailieu.idLH = lh.ID;                
                tailieu.thoiGian = DateTime.Now;
                tailieu.idTK = lh.Giangvien.TaiKhoan.iD;
                tailieu.idKN = idkn;
                dao.Insert(tailieu);
            }
            ViewBag.Message = "File Uploaded Successfully!!";
            return RedirectToAction("ChiTiet/" + idlh, "QLLopHoc");
            //}
            //catch
            //{
            //    ViewBag.Message = "File upload failed!!";
            //    return RedirectToAction("File");
            //}
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var dao = new TaiLieuDAO();
            var model = dao.GetByID(ID);
            return PartialView("Edit", model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(TaiLieu tl)
        {
            var dao = new TaiLieuDAO();
            var tailieu = dao.GetByID(tl.ID);
            if (ModelState.IsValid)
            {
                tailieu.link = tl.link;
                bool kt = dao.Update(tailieu);
                if (kt)
                {
                    TempData["testmsg"] = "Cập nhât thành công.";
                    return RedirectToAction("Viet/" + tailieu.LopHoc.ID, "Viet");
                }
                else
                {
                    TempData["testmsg"] = "Cập nhât không thành công.";
                }
            }        
            return RedirectToAction("Index/" + tailieu.LopHoc.ID+ "#custom-tabs-four-onlineclasss", "QLLopHoc");
        }

        [HttpPost]
        public ActionResult Editlh(LopHoc lophoc)
        {
            if (ModelState.IsValid)
            {
                var dao = new LopHocDAO();
                bool kt = dao.Update(lophoc);
                if (kt)
                {
                    TempData["testmsg"] = "Cập nhât thành công.";
                }
                else
                {
                    TempData["testmsg"] = "Cập nhât không thành công.";

                }
            }
            return RedirectToAction("chitietlophoc/" + lophoc.ID, "QLLopHoc");
        }

     
        [HttpPost]
        public ActionResult UpimgLop(LopHoc lh, HttpPostedFileBase img)
        {
            if (img != null && img.ContentLength > 0)
            {
                img.SaveAs(Server.MapPath("~/Content/Data/image/") + img.FileName);
                lh.hinh = "Content/Data/image/" + img.FileName;
                var dao = new LopHocDAO();
                bool kt = dao.Update(lh);
                if (kt)
                    TempData["testmsg"] = "Đổi ảnh đại diện thành công.";
                else TempData["testmsg"] = "Có lỗi trong quá trình đổi ảnh đại diện. Vui long thử lại sau.";
            }

            return RedirectToAction("chitietlophoc/" + lh.ID, "QLLopHoc");
        }

        [HttpPost]
        public ActionResult BinhLuan(int idlh, string noidung, int idtk, int idcha = 0)
        {
            var tk = new TaiKhoanDAO().FindByID(idtk);
            var lh = new LopHocDAO().GetByID(idlh);
            var dao = new BinhLuanDAO();
            var bl = new BinhLuan();
            bl.noiDung = noidung;
            bl.idLH = idlh;
            if (idcha == 0) bl.idCha = null;
            else bl.idCha = idcha;
            bl.thoiGian = DateTime.Now;
            bl.idTK = idtk;
            int kt = 0;
            try
            {
                kt = dao.Insert(bl);
                var daotb = new ThongBaoDAO();
                var tb = new ThongBao();
                tb.icon = "a fa-comment";
                tb.ngay = DateTime.Now;
                tb.trangThai = 0;
                tb.idTK = lh.Giangvien.TaiKhoan.iD;
                tb.link = "http://localhost:52790/GiaoVien/Hoc/" + idlh;
                tb.noiDung = tk.hovaten + " đã bình luận vào lớp học " + lh.tenLopHoc + " của bạn.";
                daotb.Insert(tb);
            }
            catch (Exception e)
            {
                TempData["testmsg"] = "Có lỗi trong quá trình bình luận. Vui lòng thử lại sau. \nLỗi: " + e.Message;
                return RedirectToAction("chitietlophoc/" + idlh, "QLLopHoc");
            }

            if (kt != 0)
            {
                TempData["testmsg"] = "Bình luận thành công.";
                return RedirectToAction("chitietlophoc/" + idlh, "QLLopHoc");
            }
            else
            {
                TempData["testmsg"] = "Có lỗi trong quá trình bình luận. Vui lòng thử lại sau.";
                return RedirectToAction("chitietlophoc/" + idlh, "QLLopHoc");
            }
        }

        public ActionResult Baitap(LopHoc lopHoc, int idkn)
        {
            var lh = new LopHocDAO().GetByID(lopHoc.ID);
            ViewBag.lophoc = lh;
            ViewBag.idkn = idkn;
            IEnumerable<TaiLieu> audiolist = null;
            if (lh.TaiLieux.Count() > 0) { audiolist = lh.TaiLieux.Where(x => x.idLH == lopHoc.ID && x.idKN == idkn && !string.IsNullOrEmpty(x.idBT.ToString())); }
            return View(audiolist);
        }
        
        [HttpGet]
        public ActionResult CreateBT(int idlh, int idkn, int stn)
        {
            var lh = new LopHocDAO().GetByID(idlh);
            ViewBag.lophoc = lh;
            ViewBag.idkn = idkn;
            var bt = new BaiTap();
            for (int i = 0; i < stn; i++)
            {
                var ch = new CauHoi();
                bt.CauHois.Add(ch);
            }           
            return View("CreateBT", bt); 
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateBT(List<CauHoi> cauhoi, HttpPostedFileBase file, BaiTap baitap, string tuluan, int idlh, int idkn, string ngaynop)
        {
            var lh = new LopHocDAO().GetByID(idlh);
            var dao = new BaiTapDAO();
            if (file != null && file.ContentLength > 0 )
            {                
                string _FileName = Path.GetFileName(file.FileName);
                string path = "Content/Data/baitap/lh" + idlh + "/kn"+idkn+"/";
                string _path = Path.Combine(Server.MapPath("~/" + path), _FileName);
                Directory.CreateDirectory(Path.Combine(Server.MapPath("~/"+path)));
                file.SaveAs(_path);
                int fileSize = file.ContentLength;
                int Size = fileSize / 1000000;                
                var tailieu = new TaiLieu();
                tailieu.ten = _FileName;
                tailieu.FileSize = Size;
                tailieu.link = path + _FileName;
                tailieu.idLH = lh.ID;
                tailieu.thoiGian = DateTime.Now;
                tailieu.idTK = lh.Giangvien.TaiKhoan.iD;
                tailieu.idKN = idkn;
                tailieu.idBT = baitap.ID;
                baitap.TaiLieux.Add(tailieu);
            }
            else
            {
                var tailieu = new TaiLieu();
                tailieu.idLH = lh.ID;
                tailieu.thoiGian = DateTime.Now;
                tailieu.idTK = lh.Giangvien.TaiKhoan.iD;
                tailieu.idKN = idkn;
                tailieu.idBT = baitap.ID;
                tailieu.link = baitap.tenBT + baitap.ID;
                baitap.TaiLieux.Add(tailieu);
            }
            baitap.ngayDang =DateTime.Now;
           //06/14/2021 10:33 PM
            string ngay = ngaynop.Split(' ')[0];
            string gio = ngaynop.Split(' ')[1];
            string tt = ngaynop.Split(' ')[2];
            int h = int.Parse(gio.Split(':')[0]);
            if (tt == "PM") h += 12;
           
            DateTime tnn = new DateTime(int.Parse(ngay.Split('/')[2]), int.Parse(ngay.Split('/')[0]), int.Parse(ngay.Split('/')[1]),h , int.Parse(gio.Split(':')[1]),0, DateTimeKind.Utc);
            baitap.ngayNop = tnn;

            baitap.tuLuan = tuluan;
            baitap.CauHois = cauhoi;
            baitap.trangThai = 1;       //0:đóng 1:mở
            try
            {
                dao.Insert(baitap);
                TempData["testmsg"] = "Thêm bài tập thành công.";
            }
            catch (Exception ex)
            {
                TempData["testmsg"] = "Thêm bài tập không thành công.\n"+ex.Message;
            }
            return RedirectToAction("ChiTiet/" + lh.ID, "QLLopHoc");
        }

        public ActionResult Chitietbaitap(int idbt)
        {
            var dao = new BaiTapDAO();
            var model = dao.GetByID(idbt);
            ViewBag.CountSubmit = dao.CountSubmit(idbt);
            var listhv = dao.ListHV_BT(idbt);
            ViewBag.listhv = listhv;
            return View(model);
        }
    }
}