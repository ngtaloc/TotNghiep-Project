using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebEng.Areas.GiaoVien.Controllers
{
    [Authorize(Roles = "GiaoVien")]
    public class MoLopController : Controller
    {
        // GET: GiaoVien/GiaoVien
        [HttpGet]
        public ActionResult Index()
        {
            var model = new LopHoc();
            return View(model);
        }



        [HttpPost]
        public ActionResult Index(LopHoc lophoc, bool Listening = false, bool Speaking = false, bool Reading = false, bool Writing = false, string lvListening = null, string lvSpeaking = null, string lvReading = null, string lvWriting = null, int sothang = 0,
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
                    lophoc.ngayDangKy = DateTime.Now;
                    int idlh = daoLH.Insert(lophoc); // insert
                    
                    //update lịch học
                    lophoc = daoLH.GetByID(idlh);
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
                                        return RedirectToAction("Index", "MoLop");
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
                                        return RedirectToAction("Index", "MoLop");
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
                                        return RedirectToAction("Index", "MoLop");
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
                                        return RedirectToAction("Index", "MoLop");
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
                                        return RedirectToAction("Index", "MoLop");
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
                                        return RedirectToAction("Index", "MoLop");
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
                                        return RedirectToAction("Index", "MoLop");
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
                    lophoc.soBuoi = buoi;
                    int a = daoLH.updateAll(lophoc);

                    //Từ tiền trong tài khoản
                    LichSuGD lsgd = new LichSuGD();
                    lsgd.idVT = gv.TaiKhoan.ViTiens.FirstOrDefault().iD;
                    lsgd.LoaiGD = 1;
                    lsgd.SoTienGD = 100000;
                    lsgd.TenGD = "Có tên " + lophoc.tenLopHoc + " và mã lớp LH" + lophoc.ID + " với giá 100.000 VNĐ";
                    lsgd.ThoiGiangGD = DateTime.Now;
                    int idgd = new LichSuGDDAO().Insert(lsgd);
                    gv.TaiKhoan.ViTiens.FirstOrDefault().SoDu -= 100000;
                    bool tru = new ViTienDAO().Update(gv.TaiKhoan.ViTiens.FirstOrDefault());

                    //return mes
                    ModelState.AddModelError("", "Tạo lớp thành công");
                    TempData["testmsg"] = "Tạo lớp thành công";
                    return RedirectToAction("ChiTiet/" + idlh, "QLLopHoc");

                }
                catch (Exception e)
                {
                    TempData["testmsg"] = "Có lỗi trong quá trình tạo lớp: " + e.Message.ToString();
                    return RedirectToAction("Index", "MoLop");
                }

            }
            else
            {
                TempData["testmsg"] = "Thông tin lớp không đúng định dạng.";
                return RedirectToAction("Index", "MoLop");
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new LopHoc();
            return PartialView("Create", model);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            WebEngDbContext db = new WebEngDbContext();
            var product = db.LopHocs.Where(s => s.ID == id).First();
            db.LopHocs.Remove(product);
            db.SaveChanges();
            return RedirectToAction("chitietlophoc/" + id, "MoLop");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var dao = new LopHocDAO();
            var model = dao.GetByID(ID);
            return PartialView("Edit", model);
        }

        public ActionResult ChiTietLopHoc(int id)
        {
            var dao = new LopHocDAO();
            var model = dao.GetByID(id);
            TimeSpan Time = model.ngayEnd.Value - model.ngayBegin.Value;
            TempData["Sothang"] = (float.Parse(Time.Days.ToString()) / 30).ToString("#");
            //ViewBag.hocvien = new HocVienDAO().FindByTDN(User.Identity.Name);
            return View(model);
        }
    }
}