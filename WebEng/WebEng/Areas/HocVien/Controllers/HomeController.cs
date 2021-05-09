using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebEng.Controllers;

namespace WebEng.Areas.HocVien.Controllers
{

    [Authorize(Roles = "HocVien")]
    public class HomeController : LayoutController
    {
        // GET: HocVien/Home
      
        [HttpGet]
        public ActionResult Index()
        {
            var dao = new LopHocDAO();
			var model = dao.FindAll();
            return View(model);
        }

        [HttpPost]
        public ActionResult Find(string tim =null, bool Listening = false, bool Speaking = false, bool Reading = false, bool Writing = false, string lvListening = null, string lvSpeaking = null, string lvReading = null, string lvWriting = null)
        {
            var dao = new LopHocDAO();
            var model = dao.FindLopHocIndex(tim ,  Listening,  Speaking,  Reading , Writing ,  lvListening , lvSpeaking , lvReading , lvWriting );
            return View("Index",model);
        }

        public ActionResult chitietlophoc(int id)
		{
            
            var dao = new LopHocDAO();
            var model = dao.GetByID(id);

            return View(model);
		}
		
        [HttpPost]
        public ActionResult DangKyLop(LopHoc lh)
        {
            var dao = new DSLopHocDAO();
            var hv = new HocVienDAO().FindByTDN(User.Identity.Name);
            if (dao.HocVienInLopHoc(hv.id, lh.ID))
            {
                TempData["testmsg"] = "Bạn đã đăng ký lớp học "+lh.tenLopHoc+" rồi.";
                return RedirectToAction("Index", "Home");
            }
            var daoNgay = new NgayDAO();
            var lich = daoNgay.FindByTDN(User.Identity.Name);
            var lichlop = daoNgay.FindByLopHoc(lh.ID);
            foreach(var item in lichlop)
            {
                foreach(var it in lich)
                {
                    if(item.nam==it.nam && it.Thang.iD == item.Thang.iD)
                    {
                        if(it.ngay1!= null && item.ngay1 != null)
                        {
                            if (int.Parse(it.ngay1.Split('-')[4]) < int.Parse(item.ngay1.Split('-')[6]) && int.Parse(it.ngay1.Split('-')[6]) > int.Parse(item.ngay1.Split('-')[4])
                               || int.Parse(it.ngay1.Split('-')[4]) == int.Parse(item.ngay1.Split('-')[6]) && int.Parse(it.ngay1.Split('-')[5]) < int.Parse(item.ngay1.Split('-')[7])
                               || int.Parse(it.ngay1.Split('-')[6]) == int.Parse(item.ngay1.Split('-')[4]) && int.Parse(it.ngay1.Split('-')[7]) > int.Parse(item.ngay1.Split('-')[5])
                            ){
                                var ngay = it.ngay1.Split('-');
                                TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        if (it.ngay2 != null && item.ngay2 != null)
                        if (int.Parse(it.ngay2.Split('-')[4]) < int.Parse(item.ngay2.Split('-')[6]) && int.Parse(it.ngay2.Split('-')[6]) > int.Parse(item.ngay2.Split('-')[4])
                            || int.Parse(it.ngay2.Split('-')[4]) == int.Parse(item.ngay2.Split('-')[6]) && int.Parse(it.ngay2.Split('-')[5]) < int.Parse(item.ngay2.Split('-')[7])
                            || int.Parse(it.ngay2.Split('-')[6]) == int.Parse(item.ngay2.Split('-')[4]) && int.Parse(it.ngay2.Split('-')[7]) > int.Parse(item.ngay2.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay2.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay3 != null && item.ngay3 != null)
                        if (int.Parse(it.ngay3.Split('-')[4]) < int.Parse(item.ngay3.Split('-')[6]) && int.Parse(it.ngay3.Split('-')[6]) > int.Parse(item.ngay3.Split('-')[4])
                              || int.Parse(it.ngay3.Split('-')[4]) == int.Parse(item.ngay3.Split('-')[6]) && int.Parse(it.ngay3.Split('-')[5]) < int.Parse(item.ngay3.Split('-')[7])
                              || int.Parse(it.ngay3.Split('-')[6]) == int.Parse(item.ngay3.Split('-')[4]) && int.Parse(it.ngay3.Split('-')[7]) > int.Parse(item.ngay3.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay3.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay4 != null && item.ngay4 != null)
                        if (int.Parse(it.ngay4.Split('-')[4]) < int.Parse(item.ngay4.Split('-')[6]) && int.Parse(it.ngay4.Split('-')[6]) > int.Parse(item.ngay4.Split('-')[4])
                              || int.Parse(it.ngay4.Split('-')[4]) == int.Parse(item.ngay4.Split('-')[6]) && int.Parse(it.ngay4.Split('-')[5]) < int.Parse(item.ngay4.Split('-')[7])
                              || int.Parse(it.ngay4.Split('-')[6]) == int.Parse(item.ngay4.Split('-')[4]) && int.Parse(it.ngay4.Split('-')[7]) > int.Parse(item.ngay4.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay4.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay5 != null && item.ngay5 != null)
                        if (int.Parse(it.ngay5.Split('-')[4]) < int.Parse(item.ngay5.Split('-')[6]) && int.Parse(it.ngay5.Split('-')[6]) > int.Parse(item.ngay5.Split('-')[4])
                              || int.Parse(it.ngay5.Split('-')[4]) == int.Parse(item.ngay5.Split('-')[6]) && int.Parse(it.ngay5.Split('-')[5]) < int.Parse(item.ngay5.Split('-')[7])
                              || int.Parse(it.ngay5.Split('-')[6]) == int.Parse(item.ngay5.Split('-')[4]) && int.Parse(it.ngay5.Split('-')[7]) > int.Parse(item.ngay5.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay5.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay6 != null && item.ngay6 != null)
                        if (int.Parse(it.ngay6.Split('-')[4]) < int.Parse(item.ngay6.Split('-')[6]) && int.Parse(it.ngay6.Split('-')[6]) > int.Parse(item.ngay6.Split('-')[4])
                              || int.Parse(it.ngay6.Split('-')[4]) == int.Parse(item.ngay6.Split('-')[6]) && int.Parse(it.ngay6.Split('-')[5]) < int.Parse(item.ngay6.Split('-')[7])
                              || int.Parse(it.ngay6.Split('-')[6]) == int.Parse(item.ngay6.Split('-')[4]) && int.Parse(it.ngay6.Split('-')[7]) > int.Parse(item.ngay6.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay6.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if(it.ngay7!= null && item.ngay7!=null)
                        if (int.Parse(it.ngay7.Split('-')[4]) < int.Parse(item.ngay7.Split('-')[6]) && int.Parse(it.ngay7.Split('-')[6]) > int.Parse(item.ngay7.Split('-')[4])
                              || int.Parse(it.ngay7.Split('-')[4]) == int.Parse(item.ngay7.Split('-')[6]) && int.Parse(it.ngay7.Split('-')[5]) < int.Parse(item.ngay7.Split('-')[7])
                              || int.Parse(it.ngay7.Split('-')[6]) == int.Parse(item.ngay7.Split('-')[4]) && int.Parse(it.ngay7.Split('-')[7]) > int.Parse(item.ngay7.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay7.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if(it.ngay8!= null && item.ngay8!=null)
                        if (int.Parse(it.ngay8.Split('-')[4]) < int.Parse(item.ngay8.Split('-')[6]) && int.Parse(it.ngay8.Split('-')[6]) > int.Parse(item.ngay8.Split('-')[4])
                              || int.Parse(it.ngay8.Split('-')[4]) == int.Parse(item.ngay8.Split('-')[6]) && int.Parse(it.ngay8.Split('-')[5]) < int.Parse(item.ngay8.Split('-')[7])
                              || int.Parse(it.ngay8.Split('-')[6]) == int.Parse(item.ngay8.Split('-')[4]) && int.Parse(it.ngay8.Split('-')[7]) > int.Parse(item.ngay8.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay8.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if(it.ngay9!= null && item.ngay9!=null)
                        if (int.Parse(it.ngay9.Split('-')[4]) < int.Parse(item.ngay9.Split('-')[6]) && int.Parse(it.ngay9.Split('-')[6]) > int.Parse(item.ngay9.Split('-')[4])
                              || int.Parse(it.ngay9.Split('-')[4]) == int.Parse(item.ngay9.Split('-')[6]) && int.Parse(it.ngay9.Split('-')[5]) < int.Parse(item.ngay9.Split('-')[7])
                              || int.Parse(it.ngay9.Split('-')[6]) == int.Parse(item.ngay9.Split('-')[4]) && int.Parse(it.ngay9.Split('-')[7]) > int.Parse(item.ngay9.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay9.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if(it.ngay10!= null && item.ngay10!=null)
                        if (int.Parse(it.ngay10.Split('-')[4]) < int.Parse(item.ngay10.Split('-')[6]) && int.Parse(it.ngay10.Split('-')[6]) > int.Parse(item.ngay10.Split('-')[4])
                              || int.Parse(it.ngay10.Split('-')[4]) == int.Parse(item.ngay10.Split('-')[6]) && int.Parse(it.ngay10.Split('-')[5]) < int.Parse(item.ngay10.Split('-')[7])
                              || int.Parse(it.ngay10.Split('-')[6]) == int.Parse(item.ngay10.Split('-')[4]) && int.Parse(it.ngay10.Split('-')[7]) > int.Parse(item.ngay10.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay10.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if(it.ngay11!= null && item.ngay11!=null)
                        if (int.Parse(it.ngay11.Split('-')[4]) < int.Parse(item.ngay11.Split('-')[6]) && int.Parse(it.ngay11.Split('-')[6]) > int.Parse(item.ngay11.Split('-')[4])
                              || int.Parse(it.ngay11.Split('-')[4]) == int.Parse(item.ngay11.Split('-')[6]) && int.Parse(it.ngay11.Split('-')[5]) < int.Parse(item.ngay11.Split('-')[7])
                              || int.Parse(it.ngay11.Split('-')[6]) == int.Parse(item.ngay11.Split('-')[4]) && int.Parse(it.ngay11.Split('-')[7]) > int.Parse(item.ngay11.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay11.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if(it.ngay12!= null && item.ngay12!=null)
                        if (int.Parse(it.ngay12.Split('-')[4]) < int.Parse(item.ngay12.Split('-')[6]) && int.Parse(it.ngay12.Split('-')[6]) > int.Parse(item.ngay12.Split('-')[4])
                              || int.Parse(it.ngay12.Split('-')[4]) == int.Parse(item.ngay12.Split('-')[6]) && int.Parse(it.ngay12.Split('-')[5]) < int.Parse(item.ngay12.Split('-')[7])
                              || int.Parse(it.ngay12.Split('-')[6]) == int.Parse(item.ngay12.Split('-')[4]) && int.Parse(it.ngay12.Split('-')[7]) > int.Parse(item.ngay12.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay12.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if(it.ngay13!= null && item.ngay13!=null)
                        if (int.Parse(it.ngay13.Split('-')[4]) < int.Parse(item.ngay13.Split('-')[6]) && int.Parse(it.ngay13.Split('-')[6]) > int.Parse(item.ngay13.Split('-')[4])
                              || int.Parse(it.ngay13.Split('-')[4]) == int.Parse(item.ngay13.Split('-')[6]) && int.Parse(it.ngay13.Split('-')[5]) < int.Parse(item.ngay13.Split('-')[7])
                              || int.Parse(it.ngay13.Split('-')[6]) == int.Parse(item.ngay13.Split('-')[4]) && int.Parse(it.ngay13.Split('-')[7]) > int.Parse(item.ngay13.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay13.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if(it.ngay14!= null && item.ngay14!=null)
                        if (int.Parse(it.ngay14.Split('-')[4]) < int.Parse(item.ngay14.Split('-')[6]) && int.Parse(it.ngay14.Split('-')[6]) > int.Parse(item.ngay14.Split('-')[4])
                              || int.Parse(it.ngay14.Split('-')[4]) == int.Parse(item.ngay14.Split('-')[6]) && int.Parse(it.ngay14.Split('-')[5]) < int.Parse(item.ngay14.Split('-')[7])
                              || int.Parse(it.ngay14.Split('-')[6]) == int.Parse(item.ngay14.Split('-')[4]) && int.Parse(it.ngay14.Split('-')[7]) > int.Parse(item.ngay14.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay14.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if(it.ngay15!= null && item.ngay15!=null)
                        if (int.Parse(it.ngay15.Split('-')[4]) < int.Parse(item.ngay15.Split('-')[6]) && int.Parse(it.ngay15.Split('-')[6]) > int.Parse(item.ngay15.Split('-')[4])
                              || int.Parse(it.ngay15.Split('-')[4]) == int.Parse(item.ngay15.Split('-')[6]) && int.Parse(it.ngay15.Split('-')[5]) < int.Parse(item.ngay15.Split('-')[7])
                              || int.Parse(it.ngay15.Split('-')[6]) == int.Parse(item.ngay15.Split('-')[4]) && int.Parse(it.ngay15.Split('-')[7]) > int.Parse(item.ngay15.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay15.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay16 != null && item.ngay16 != null)
                        if (int.Parse(it.ngay16.Split('-')[4]) < int.Parse(item.ngay16.Split('-')[6]) && int.Parse(it.ngay16.Split('-')[6]) > int.Parse(item.ngay16.Split('-')[4])
                              || int.Parse(it.ngay16.Split('-')[4]) == int.Parse(item.ngay16.Split('-')[6]) && int.Parse(it.ngay16.Split('-')[5]) < int.Parse(item.ngay16.Split('-')[7])
                              || int.Parse(it.ngay16.Split('-')[6]) == int.Parse(item.ngay16.Split('-')[4]) && int.Parse(it.ngay16.Split('-')[7]) > int.Parse(item.ngay16.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay16.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay17 != null && item.ngay17 != null)
                        if (int.Parse(it.ngay17.Split('-')[4]) < int.Parse(item.ngay17.Split('-')[6]) && int.Parse(it.ngay17.Split('-')[6]) > int.Parse(item.ngay17.Split('-')[4])
                              || int.Parse(it.ngay17.Split('-')[4]) == int.Parse(item.ngay17.Split('-')[6]) && int.Parse(it.ngay17.Split('-')[5]) < int.Parse(item.ngay17.Split('-')[7])
                              || int.Parse(it.ngay17.Split('-')[6]) == int.Parse(item.ngay17.Split('-')[4]) && int.Parse(it.ngay17.Split('-')[7]) > int.Parse(item.ngay17.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay17.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay18 != null && item.ngay18 != null)
                            if (int.Parse(it.ngay18.Split('-')[4]) < int.Parse(item.ngay18.Split('-')[6]) && int.Parse(it.ngay18.Split('-')[6]) > int.Parse(item.ngay18.Split('-')[4])
                              || int.Parse(it.ngay18.Split('-')[4]) == int.Parse(item.ngay18.Split('-')[6]) && int.Parse(it.ngay18.Split('-')[5]) < int.Parse(item.ngay18.Split('-')[7])
                              || int.Parse(it.ngay18.Split('-')[6]) == int.Parse(item.ngay18.Split('-')[4]) && int.Parse(it.ngay18.Split('-')[7]) > int.Parse(item.ngay18.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay18.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay19 != null && item.ngay19 != null)
                            if (int.Parse(it.ngay19.Split('-')[4]) < int.Parse(item.ngay19.Split('-')[6]) && int.Parse(it.ngay19.Split('-')[6]) > int.Parse(item.ngay19.Split('-')[4])
                              || int.Parse(it.ngay19.Split('-')[4]) == int.Parse(item.ngay19.Split('-')[6]) && int.Parse(it.ngay19.Split('-')[5]) < int.Parse(item.ngay19.Split('-')[7])
                              || int.Parse(it.ngay19.Split('-')[6]) == int.Parse(item.ngay19.Split('-')[4]) && int.Parse(it.ngay19.Split('-')[7]) > int.Parse(item.ngay19.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay19.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay20 != null && item.ngay20 != null)
                            if (int.Parse(it.ngay20.Split('-')[4]) < int.Parse(item.ngay20.Split('-')[6]) && int.Parse(it.ngay20.Split('-')[6]) > int.Parse(item.ngay20.Split('-')[4])
                              || int.Parse(it.ngay20.Split('-')[4]) == int.Parse(item.ngay20.Split('-')[6]) && int.Parse(it.ngay20.Split('-')[5]) < int.Parse(item.ngay20.Split('-')[7])
                              || int.Parse(it.ngay20.Split('-')[6]) == int.Parse(item.ngay20.Split('-')[4]) && int.Parse(it.ngay20.Split('-')[7]) > int.Parse(item.ngay20.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay20.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay21 != null && item.ngay21 != null)
                            if (int.Parse(it.ngay21.Split('-')[4]) < int.Parse(item.ngay21.Split('-')[6]) && int.Parse(it.ngay21.Split('-')[6]) > int.Parse(item.ngay21.Split('-')[4])
                              || int.Parse(it.ngay21.Split('-')[4]) == int.Parse(item.ngay21.Split('-')[6]) && int.Parse(it.ngay21.Split('-')[5]) < int.Parse(item.ngay21.Split('-')[7])
                              || int.Parse(it.ngay21.Split('-')[6]) == int.Parse(item.ngay21.Split('-')[4]) && int.Parse(it.ngay21.Split('-')[7]) > int.Parse(item.ngay21.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay21.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay22 != null && item.ngay22 != null)
                            if (int.Parse(it.ngay22.Split('-')[4]) < int.Parse(item.ngay22.Split('-')[6]) && int.Parse(it.ngay22.Split('-')[6]) > int.Parse(item.ngay22.Split('-')[4])
                              || int.Parse(it.ngay22.Split('-')[4]) == int.Parse(item.ngay22.Split('-')[6]) && int.Parse(it.ngay22.Split('-')[5]) < int.Parse(item.ngay22.Split('-')[7])
                              || int.Parse(it.ngay22.Split('-')[6]) == int.Parse(item.ngay22.Split('-')[4]) && int.Parse(it.ngay22.Split('-')[7]) > int.Parse(item.ngay22.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay22.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay23 != null && item.ngay23 != null)
                            if (int.Parse(it.ngay23.Split('-')[4]) < int.Parse(item.ngay23.Split('-')[6]) && int.Parse(it.ngay23.Split('-')[6]) > int.Parse(item.ngay23.Split('-')[4])
                              || int.Parse(it.ngay23.Split('-')[4]) == int.Parse(item.ngay23.Split('-')[6]) && int.Parse(it.ngay23.Split('-')[5]) < int.Parse(item.ngay23.Split('-')[7])
                              || int.Parse(it.ngay23.Split('-')[6]) == int.Parse(item.ngay23.Split('-')[4]) && int.Parse(it.ngay23.Split('-')[7]) > int.Parse(item.ngay23.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay23.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay24 != null && item.ngay24 != null)
                            if (int.Parse(it.ngay24.Split('-')[4]) < int.Parse(item.ngay24.Split('-')[6]) && int.Parse(it.ngay24.Split('-')[6]) > int.Parse(item.ngay24.Split('-')[4])
                              || int.Parse(it.ngay24.Split('-')[4]) == int.Parse(item.ngay24.Split('-')[6]) && int.Parse(it.ngay24.Split('-')[5]) < int.Parse(item.ngay24.Split('-')[7])
                              || int.Parse(it.ngay24.Split('-')[6]) == int.Parse(item.ngay24.Split('-')[4]) && int.Parse(it.ngay24.Split('-')[7]) > int.Parse(item.ngay24.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay24.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay25 != null && item.ngay25 != null)
                            if (int.Parse(it.ngay25.Split('-')[4]) < int.Parse(item.ngay25.Split('-')[6]) && int.Parse(it.ngay25.Split('-')[6]) > int.Parse(item.ngay25.Split('-')[4])
                              || int.Parse(it.ngay25.Split('-')[4]) == int.Parse(item.ngay25.Split('-')[6]) && int.Parse(it.ngay25.Split('-')[5]) < int.Parse(item.ngay25.Split('-')[7])
                              || int.Parse(it.ngay25.Split('-')[6]) == int.Parse(item.ngay25.Split('-')[4]) && int.Parse(it.ngay25.Split('-')[7]) > int.Parse(item.ngay25.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay25.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay26 != null && item.ngay26 != null)
                            if (int.Parse(it.ngay26.Split('-')[4]) < int.Parse(item.ngay26.Split('-')[6]) && int.Parse(it.ngay26.Split('-')[6]) > int.Parse(item.ngay26.Split('-')[4])
                              || int.Parse(it.ngay26.Split('-')[4]) == int.Parse(item.ngay26.Split('-')[6]) && int.Parse(it.ngay26.Split('-')[5]) < int.Parse(item.ngay26.Split('-')[7])
                              || int.Parse(it.ngay26.Split('-')[6]) == int.Parse(item.ngay26.Split('-')[4]) && int.Parse(it.ngay26.Split('-')[7]) > int.Parse(item.ngay26.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay26.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay27 != null && item.ngay27 != null)
                            if (int.Parse(it.ngay27.Split('-')[4]) < int.Parse(item.ngay27.Split('-')[6]) && int.Parse(it.ngay27.Split('-')[6]) > int.Parse(item.ngay27.Split('-')[4])
                              || int.Parse(it.ngay27.Split('-')[4]) == int.Parse(item.ngay27.Split('-')[6]) && int.Parse(it.ngay27.Split('-')[5]) < int.Parse(item.ngay27.Split('-')[7])
                              || int.Parse(it.ngay27.Split('-')[6]) == int.Parse(item.ngay27.Split('-')[4]) && int.Parse(it.ngay27.Split('-')[7]) > int.Parse(item.ngay27.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay27.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay28 != null && item.ngay28 != null)
                            if (int.Parse(it.ngay28.Split('-')[4]) < int.Parse(item.ngay28.Split('-')[6]) && int.Parse(it.ngay28.Split('-')[6]) > int.Parse(item.ngay28.Split('-')[4])
                              || int.Parse(it.ngay28.Split('-')[4]) == int.Parse(item.ngay28.Split('-')[6]) && int.Parse(it.ngay28.Split('-')[5]) < int.Parse(item.ngay28.Split('-')[7])
                              || int.Parse(it.ngay28.Split('-')[6]) == int.Parse(item.ngay28.Split('-')[4]) && int.Parse(it.ngay28.Split('-')[7]) > int.Parse(item.ngay28.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay28.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay29 != null && item.ngay29 != null)
                            if (int.Parse(it.ngay29.Split('-')[4]) < int.Parse(item.ngay29.Split('-')[6]) && int.Parse(it.ngay29.Split('-')[6]) > int.Parse(item.ngay29.Split('-')[4])
                              || int.Parse(it.ngay29.Split('-')[4]) == int.Parse(item.ngay29.Split('-')[6]) && int.Parse(it.ngay29.Split('-')[5]) < int.Parse(item.ngay29.Split('-')[7])
                              || int.Parse(it.ngay29.Split('-')[6]) == int.Parse(item.ngay29.Split('-')[4]) && int.Parse(it.ngay29.Split('-')[7]) > int.Parse(item.ngay29.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay29.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay30 != null && item.ngay30 != null)
                            if (int.Parse(it.ngay30.Split('-')[4]) < int.Parse(item.ngay30.Split('-')[6]) && int.Parse(it.ngay30.Split('-')[6]) > int.Parse(item.ngay30.Split('-')[4])
                              || int.Parse(it.ngay30.Split('-')[4]) == int.Parse(item.ngay30.Split('-')[6]) && int.Parse(it.ngay30.Split('-')[5]) < int.Parse(item.ngay30.Split('-')[7])
                              || int.Parse(it.ngay30.Split('-')[6]) == int.Parse(item.ngay30.Split('-')[4]) && int.Parse(it.ngay30.Split('-')[7]) > int.Parse(item.ngay30.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay30.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                        if (it.ngay31 != null && item.ngay31 != null)
                            if (int.Parse(it.ngay31.Split('-')[4]) < int.Parse(item.ngay31.Split('-')[6]) && int.Parse(it.ngay31.Split('-')[6]) > int.Parse(item.ngay31.Split('-')[4])
                              || int.Parse(it.ngay31.Split('-')[4]) == int.Parse(item.ngay31.Split('-')[6]) && int.Parse(it.ngay31.Split('-')[5]) < int.Parse(item.ngay31.Split('-')[7])
                              || int.Parse(it.ngay31.Split('-')[6]) == int.Parse(item.ngay31.Split('-')[4]) && int.Parse(it.ngay31.Split('-')[7]) > int.Parse(item.ngay31.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay31.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("Index", "Home");
                        }
                       

                    }
                }
                
            }
           
            var dslh = new DSLopHoc();
            dslh.idHV = hv.id;
            dslh.idLH = lh.ID;            
            
            int kt = dao.Insert(dslh);
            if(kt != 0)
            {
                TempData["testmsg"] = "Đăng ký thành công";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["testmsg"] = "Có lỗi trong quá trình đăng ký";
                return RedirectToAction("Index", "Home");
            }
            //1 - 15 - 4 - 2021 - 9 - 00 - 11 - 30    2
            //1 - 15 - 4 - 2021 - 11 - 30 - 12 - 30    3
            //0   1    2    3     4   5    6     7

        }

    }
}