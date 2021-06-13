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
    public class TimController : LayoutController
    {
        // GET: HocVien/Tim
      
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
            TimeSpan Time = model.ngayEnd.Value - model.ngayBegin.Value ;
            TempData["Sothang"] = (float.Parse(Time.Days.ToString()) / 30).ToString("#");
            ViewBag.hocvien = new HocVienDAO().FindByTDN(User.Identity.Name);
            return View(model);
		}
		
        [HttpGet]
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
                foreach(var it in item.DSLopHocs)
                {
                    if (!String.IsNullOrEmpty(it.danhgia.ToString()) && it.danhgia.Value != 0)
                    {
                        danhgiaSo++;
                        int dg= int.Parse(it.danhgia.ToString());
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
        [HttpPost]
        public ActionResult InfoGV(int idgv,int rating=0, string nhanxet=null, int idlh=0)
        {
            if (idlh == 0)
            {
                TempData["testmsg"] = "Giáo viên này chưa có lớp học nào hoàng thành.";
                return RedirectToAction("InfoGV/" + idgv, "Tim");;
            }
            if (rating == 0)
            {
                TempData["testmsg"] = "Vui lòng chọn điểm đánh giá .";
                return RedirectToAction("InfoGV/" + idgv, "Tim");;
            }
            if(nhanxet == null)
            {
                TempData["testmsg"] = "Vui lòng cho vài lời nhận xét.";
                return RedirectToAction("InfoGV/" + idgv, "Tim");;
            }
            var hv = new HocVienDAO().FindByTDN(User.Identity.Name);
            var lh = new LopHocDAO().GetByID(idlh);
            var dslh = lh.DSLopHocs.FirstOrDefault(x => x.HocVien.TaiKhoan.tenDangNhap == User.Identity.Name && x.idLH == idlh);
            if (dslh == null)
            {
                TempData["testmsg"] = "Bạn hãy hoành thành lớp học "+lh.tenLopHoc+" của giáo viên để có thể đánh giá.";
                return RedirectToAction("InfoGV/" + idgv, "Tim");;
            }
            if (!string.IsNullOrEmpty(dslh.danhgia.ToString()))
            {
                TempData["testmsg"] = "Bạn đã đánh giá & nhận xét rồi.";
                return RedirectToAction("InfoGV/" + idgv, "Tim");;
            }
            dslh.danhgia = rating;
            dslh.binhluan = nhanxet;
            dslh.ngayDanhGia = DateTime.Now;
            bool kt = new DSLopHocDAO().Update(dslh);

            TempData["testmsg"] = "Đánh giá & nhận xét thành công .";
            return RedirectToAction("InfoGV/" + idgv, "Tim");
        }
       

        [HttpPost]
        public ActionResult BinhLuan(int idlh, string noidung,int idtk, int idcha=0)
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
                return RedirectToAction("chitietlophoc/" + idlh, "Tim");
            }

            if (kt != 0)
            {
                TempData["testmsg"] = "Bình luận thành công.";
                return RedirectToAction("chitietlophoc/" + idlh, "Tim");
            }
            else
            {
                TempData["testmsg"] = "Có lỗi trong quá trình bình luận. Vui lòng thử lại sau.";
                return RedirectToAction("chitietlophoc/"+idlh, "Tim");
            }
        }


        [HttpPost]
        public ActionResult DangKyLop(LopHoc lh)
        {
            var dao = new DSLopHocDAO();
            var hv = new HocVienDAO().FindByTDN(User.Identity.Name);
            var lophoc = new LopHocDAO().GetByID(lh.ID);
            if (lophoc.trangThai == 1)
            {
                TempData["testmsg"] = "Lớp học nãy đã Ngừng Tuyển Sinh, vui lòng đăng ký lơp học khác.";
                return RedirectToAction("chitietlophoc/" + lophoc.ID, "Tim");
            }
            if (lophoc.trangThai == 2 )
            {
                TempData["testmsg"] = "Lớp học nãy đã Bắt Đầu, vui lòng đăng ký lơp học khác.";
                return RedirectToAction("chitietlophoc/" + lophoc.ID, "Tim");
            }
            if (lophoc.trangThai == 3)
            {
                TempData["testmsg"] = "Lớp học nãy đã Kết Thúc, vui lòng đăng ký lơp học khác.";
                return RedirectToAction("chitietlophoc/" + lophoc.ID, "Tim");
            }
            if (dao.HocVienInLopHoc(hv.id, lophoc.ID))
            {
                TempData["testmsg"] = "Bạn đã đăng ký lớp học "+lophoc.tenLopHoc+" rồi.";
                return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
            }
            var daoNgay = new NgayDAO();
            var lich = daoNgay.FindByTDN(User.Identity.Name);
            var lichlop = daoNgay.FindByLopHoc(lophoc.ID);
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
                                return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
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
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay3 != null && item.ngay3 != null)
                        if (int.Parse(it.ngay3.Split('-')[4]) < int.Parse(item.ngay3.Split('-')[6]) && int.Parse(it.ngay3.Split('-')[6]) > int.Parse(item.ngay3.Split('-')[4])
                              || int.Parse(it.ngay3.Split('-')[4]) == int.Parse(item.ngay3.Split('-')[6]) && int.Parse(it.ngay3.Split('-')[5]) < int.Parse(item.ngay3.Split('-')[7])
                              || int.Parse(it.ngay3.Split('-')[6]) == int.Parse(item.ngay3.Split('-')[4]) && int.Parse(it.ngay3.Split('-')[7]) > int.Parse(item.ngay3.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay3.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay4 != null && item.ngay4 != null)
                        if (int.Parse(it.ngay4.Split('-')[4]) < int.Parse(item.ngay4.Split('-')[6]) && int.Parse(it.ngay4.Split('-')[6]) > int.Parse(item.ngay4.Split('-')[4])
                              || int.Parse(it.ngay4.Split('-')[4]) == int.Parse(item.ngay4.Split('-')[6]) && int.Parse(it.ngay4.Split('-')[5]) < int.Parse(item.ngay4.Split('-')[7])
                              || int.Parse(it.ngay4.Split('-')[6]) == int.Parse(item.ngay4.Split('-')[4]) && int.Parse(it.ngay4.Split('-')[7]) > int.Parse(item.ngay4.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay4.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay5 != null && item.ngay5 != null)
                        if (int.Parse(it.ngay5.Split('-')[4]) < int.Parse(item.ngay5.Split('-')[6]) && int.Parse(it.ngay5.Split('-')[6]) > int.Parse(item.ngay5.Split('-')[4])
                              || int.Parse(it.ngay5.Split('-')[4]) == int.Parse(item.ngay5.Split('-')[6]) && int.Parse(it.ngay5.Split('-')[5]) < int.Parse(item.ngay5.Split('-')[7])
                              || int.Parse(it.ngay5.Split('-')[6]) == int.Parse(item.ngay5.Split('-')[4]) && int.Parse(it.ngay5.Split('-')[7]) > int.Parse(item.ngay5.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay5.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay6 != null && item.ngay6 != null)
                        if (int.Parse(it.ngay6.Split('-')[4]) < int.Parse(item.ngay6.Split('-')[6]) && int.Parse(it.ngay6.Split('-')[6]) > int.Parse(item.ngay6.Split('-')[4])
                              || int.Parse(it.ngay6.Split('-')[4]) == int.Parse(item.ngay6.Split('-')[6]) && int.Parse(it.ngay6.Split('-')[5]) < int.Parse(item.ngay6.Split('-')[7])
                              || int.Parse(it.ngay6.Split('-')[6]) == int.Parse(item.ngay6.Split('-')[4]) && int.Parse(it.ngay6.Split('-')[7]) > int.Parse(item.ngay6.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay6.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if(it.ngay7!= null && item.ngay7!=null)
                        if (int.Parse(it.ngay7.Split('-')[4]) < int.Parse(item.ngay7.Split('-')[6]) && int.Parse(it.ngay7.Split('-')[6]) > int.Parse(item.ngay7.Split('-')[4])
                              || int.Parse(it.ngay7.Split('-')[4]) == int.Parse(item.ngay7.Split('-')[6]) && int.Parse(it.ngay7.Split('-')[5]) < int.Parse(item.ngay7.Split('-')[7])
                              || int.Parse(it.ngay7.Split('-')[6]) == int.Parse(item.ngay7.Split('-')[4]) && int.Parse(it.ngay7.Split('-')[7]) > int.Parse(item.ngay7.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay7.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if(it.ngay8!= null && item.ngay8!=null)
                        if (int.Parse(it.ngay8.Split('-')[4]) < int.Parse(item.ngay8.Split('-')[6]) && int.Parse(it.ngay8.Split('-')[6]) > int.Parse(item.ngay8.Split('-')[4])
                              || int.Parse(it.ngay8.Split('-')[4]) == int.Parse(item.ngay8.Split('-')[6]) && int.Parse(it.ngay8.Split('-')[5]) < int.Parse(item.ngay8.Split('-')[7])
                              || int.Parse(it.ngay8.Split('-')[6]) == int.Parse(item.ngay8.Split('-')[4]) && int.Parse(it.ngay8.Split('-')[7]) > int.Parse(item.ngay8.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay8.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if(it.ngay9!= null && item.ngay9!=null)
                        if (int.Parse(it.ngay9.Split('-')[4]) < int.Parse(item.ngay9.Split('-')[6]) && int.Parse(it.ngay9.Split('-')[6]) > int.Parse(item.ngay9.Split('-')[4])
                              || int.Parse(it.ngay9.Split('-')[4]) == int.Parse(item.ngay9.Split('-')[6]) && int.Parse(it.ngay9.Split('-')[5]) < int.Parse(item.ngay9.Split('-')[7])
                              || int.Parse(it.ngay9.Split('-')[6]) == int.Parse(item.ngay9.Split('-')[4]) && int.Parse(it.ngay9.Split('-')[7]) > int.Parse(item.ngay9.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay9.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if(it.ngay10!= null && item.ngay10!=null)
                        if (int.Parse(it.ngay10.Split('-')[4]) < int.Parse(item.ngay10.Split('-')[6]) && int.Parse(it.ngay10.Split('-')[6]) > int.Parse(item.ngay10.Split('-')[4])
                              || int.Parse(it.ngay10.Split('-')[4]) == int.Parse(item.ngay10.Split('-')[6]) && int.Parse(it.ngay10.Split('-')[5]) < int.Parse(item.ngay10.Split('-')[7])
                              || int.Parse(it.ngay10.Split('-')[6]) == int.Parse(item.ngay10.Split('-')[4]) && int.Parse(it.ngay10.Split('-')[7]) > int.Parse(item.ngay10.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay10.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if(it.ngay11!= null && item.ngay11!=null)
                        if (int.Parse(it.ngay11.Split('-')[4]) < int.Parse(item.ngay11.Split('-')[6]) && int.Parse(it.ngay11.Split('-')[6]) > int.Parse(item.ngay11.Split('-')[4])
                              || int.Parse(it.ngay11.Split('-')[4]) == int.Parse(item.ngay11.Split('-')[6]) && int.Parse(it.ngay11.Split('-')[5]) < int.Parse(item.ngay11.Split('-')[7])
                              || int.Parse(it.ngay11.Split('-')[6]) == int.Parse(item.ngay11.Split('-')[4]) && int.Parse(it.ngay11.Split('-')[7]) > int.Parse(item.ngay11.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay11.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if(it.ngay12!= null && item.ngay12!=null)
                        if (int.Parse(it.ngay12.Split('-')[4]) < int.Parse(item.ngay12.Split('-')[6]) && int.Parse(it.ngay12.Split('-')[6]) > int.Parse(item.ngay12.Split('-')[4])
                              || int.Parse(it.ngay12.Split('-')[4]) == int.Parse(item.ngay12.Split('-')[6]) && int.Parse(it.ngay12.Split('-')[5]) < int.Parse(item.ngay12.Split('-')[7])
                              || int.Parse(it.ngay12.Split('-')[6]) == int.Parse(item.ngay12.Split('-')[4]) && int.Parse(it.ngay12.Split('-')[7]) > int.Parse(item.ngay12.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay12.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if(it.ngay13!= null && item.ngay13!=null)
                        if (int.Parse(it.ngay13.Split('-')[4]) < int.Parse(item.ngay13.Split('-')[6]) && int.Parse(it.ngay13.Split('-')[6]) > int.Parse(item.ngay13.Split('-')[4])
                              || int.Parse(it.ngay13.Split('-')[4]) == int.Parse(item.ngay13.Split('-')[6]) && int.Parse(it.ngay13.Split('-')[5]) < int.Parse(item.ngay13.Split('-')[7])
                              || int.Parse(it.ngay13.Split('-')[6]) == int.Parse(item.ngay13.Split('-')[4]) && int.Parse(it.ngay13.Split('-')[7]) > int.Parse(item.ngay13.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay13.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if(it.ngay14!= null && item.ngay14!=null)
                        if (int.Parse(it.ngay14.Split('-')[4]) < int.Parse(item.ngay14.Split('-')[6]) && int.Parse(it.ngay14.Split('-')[6]) > int.Parse(item.ngay14.Split('-')[4])
                              || int.Parse(it.ngay14.Split('-')[4]) == int.Parse(item.ngay14.Split('-')[6]) && int.Parse(it.ngay14.Split('-')[5]) < int.Parse(item.ngay14.Split('-')[7])
                              || int.Parse(it.ngay14.Split('-')[6]) == int.Parse(item.ngay14.Split('-')[4]) && int.Parse(it.ngay14.Split('-')[7]) > int.Parse(item.ngay14.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay14.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if(it.ngay15!= null && item.ngay15!=null)
                        if (int.Parse(it.ngay15.Split('-')[4]) < int.Parse(item.ngay15.Split('-')[6]) && int.Parse(it.ngay15.Split('-')[6]) > int.Parse(item.ngay15.Split('-')[4])
                              || int.Parse(it.ngay15.Split('-')[4]) == int.Parse(item.ngay15.Split('-')[6]) && int.Parse(it.ngay15.Split('-')[5]) < int.Parse(item.ngay15.Split('-')[7])
                              || int.Parse(it.ngay15.Split('-')[6]) == int.Parse(item.ngay15.Split('-')[4]) && int.Parse(it.ngay15.Split('-')[7]) > int.Parse(item.ngay15.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay15.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay16 != null && item.ngay16 != null)
                        if (int.Parse(it.ngay16.Split('-')[4]) < int.Parse(item.ngay16.Split('-')[6]) && int.Parse(it.ngay16.Split('-')[6]) > int.Parse(item.ngay16.Split('-')[4])
                              || int.Parse(it.ngay16.Split('-')[4]) == int.Parse(item.ngay16.Split('-')[6]) && int.Parse(it.ngay16.Split('-')[5]) < int.Parse(item.ngay16.Split('-')[7])
                              || int.Parse(it.ngay16.Split('-')[6]) == int.Parse(item.ngay16.Split('-')[4]) && int.Parse(it.ngay16.Split('-')[7]) > int.Parse(item.ngay16.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay16.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay17 != null && item.ngay17 != null)
                        if (int.Parse(it.ngay17.Split('-')[4]) < int.Parse(item.ngay17.Split('-')[6]) && int.Parse(it.ngay17.Split('-')[6]) > int.Parse(item.ngay17.Split('-')[4])
                              || int.Parse(it.ngay17.Split('-')[4]) == int.Parse(item.ngay17.Split('-')[6]) && int.Parse(it.ngay17.Split('-')[5]) < int.Parse(item.ngay17.Split('-')[7])
                              || int.Parse(it.ngay17.Split('-')[6]) == int.Parse(item.ngay17.Split('-')[4]) && int.Parse(it.ngay17.Split('-')[7]) > int.Parse(item.ngay17.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay17.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay18 != null && item.ngay18 != null)
                            if (int.Parse(it.ngay18.Split('-')[4]) < int.Parse(item.ngay18.Split('-')[6]) && int.Parse(it.ngay18.Split('-')[6]) > int.Parse(item.ngay18.Split('-')[4])
                              || int.Parse(it.ngay18.Split('-')[4]) == int.Parse(item.ngay18.Split('-')[6]) && int.Parse(it.ngay18.Split('-')[5]) < int.Parse(item.ngay18.Split('-')[7])
                              || int.Parse(it.ngay18.Split('-')[6]) == int.Parse(item.ngay18.Split('-')[4]) && int.Parse(it.ngay18.Split('-')[7]) > int.Parse(item.ngay18.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay18.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay19 != null && item.ngay19 != null)
                            if (int.Parse(it.ngay19.Split('-')[4]) < int.Parse(item.ngay19.Split('-')[6]) && int.Parse(it.ngay19.Split('-')[6]) > int.Parse(item.ngay19.Split('-')[4])
                              || int.Parse(it.ngay19.Split('-')[4]) == int.Parse(item.ngay19.Split('-')[6]) && int.Parse(it.ngay19.Split('-')[5]) < int.Parse(item.ngay19.Split('-')[7])
                              || int.Parse(it.ngay19.Split('-')[6]) == int.Parse(item.ngay19.Split('-')[4]) && int.Parse(it.ngay19.Split('-')[7]) > int.Parse(item.ngay19.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay19.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay20 != null && item.ngay20 != null)
                            if (int.Parse(it.ngay20.Split('-')[4]) < int.Parse(item.ngay20.Split('-')[6]) && int.Parse(it.ngay20.Split('-')[6]) > int.Parse(item.ngay20.Split('-')[4])
                              || int.Parse(it.ngay20.Split('-')[4]) == int.Parse(item.ngay20.Split('-')[6]) && int.Parse(it.ngay20.Split('-')[5]) < int.Parse(item.ngay20.Split('-')[7])
                              || int.Parse(it.ngay20.Split('-')[6]) == int.Parse(item.ngay20.Split('-')[4]) && int.Parse(it.ngay20.Split('-')[7]) > int.Parse(item.ngay20.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay20.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay21 != null && item.ngay21 != null)
                            if (int.Parse(it.ngay21.Split('-')[4]) < int.Parse(item.ngay21.Split('-')[6]) && int.Parse(it.ngay21.Split('-')[6]) > int.Parse(item.ngay21.Split('-')[4])
                              || int.Parse(it.ngay21.Split('-')[4]) == int.Parse(item.ngay21.Split('-')[6]) && int.Parse(it.ngay21.Split('-')[5]) < int.Parse(item.ngay21.Split('-')[7])
                              || int.Parse(it.ngay21.Split('-')[6]) == int.Parse(item.ngay21.Split('-')[4]) && int.Parse(it.ngay21.Split('-')[7]) > int.Parse(item.ngay21.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay21.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay22 != null && item.ngay22 != null)
                            if (int.Parse(it.ngay22.Split('-')[4]) < int.Parse(item.ngay22.Split('-')[6]) && int.Parse(it.ngay22.Split('-')[6]) > int.Parse(item.ngay22.Split('-')[4])
                              || int.Parse(it.ngay22.Split('-')[4]) == int.Parse(item.ngay22.Split('-')[6]) && int.Parse(it.ngay22.Split('-')[5]) < int.Parse(item.ngay22.Split('-')[7])
                              || int.Parse(it.ngay22.Split('-')[6]) == int.Parse(item.ngay22.Split('-')[4]) && int.Parse(it.ngay22.Split('-')[7]) > int.Parse(item.ngay22.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay22.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay23 != null && item.ngay23 != null)
                            if (int.Parse(it.ngay23.Split('-')[4]) < int.Parse(item.ngay23.Split('-')[6]) && int.Parse(it.ngay23.Split('-')[6]) > int.Parse(item.ngay23.Split('-')[4])
                              || int.Parse(it.ngay23.Split('-')[4]) == int.Parse(item.ngay23.Split('-')[6]) && int.Parse(it.ngay23.Split('-')[5]) < int.Parse(item.ngay23.Split('-')[7])
                              || int.Parse(it.ngay23.Split('-')[6]) == int.Parse(item.ngay23.Split('-')[4]) && int.Parse(it.ngay23.Split('-')[7]) > int.Parse(item.ngay23.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay23.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay24 != null && item.ngay24 != null)
                            if (int.Parse(it.ngay24.Split('-')[4]) < int.Parse(item.ngay24.Split('-')[6]) && int.Parse(it.ngay24.Split('-')[6]) > int.Parse(item.ngay24.Split('-')[4])
                              || int.Parse(it.ngay24.Split('-')[4]) == int.Parse(item.ngay24.Split('-')[6]) && int.Parse(it.ngay24.Split('-')[5]) < int.Parse(item.ngay24.Split('-')[7])
                              || int.Parse(it.ngay24.Split('-')[6]) == int.Parse(item.ngay24.Split('-')[4]) && int.Parse(it.ngay24.Split('-')[7]) > int.Parse(item.ngay24.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay24.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay25 != null && item.ngay25 != null)
                            if (int.Parse(it.ngay25.Split('-')[4]) < int.Parse(item.ngay25.Split('-')[6]) && int.Parse(it.ngay25.Split('-')[6]) > int.Parse(item.ngay25.Split('-')[4])
                              || int.Parse(it.ngay25.Split('-')[4]) == int.Parse(item.ngay25.Split('-')[6]) && int.Parse(it.ngay25.Split('-')[5]) < int.Parse(item.ngay25.Split('-')[7])
                              || int.Parse(it.ngay25.Split('-')[6]) == int.Parse(item.ngay25.Split('-')[4]) && int.Parse(it.ngay25.Split('-')[7]) > int.Parse(item.ngay25.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay25.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay26 != null && item.ngay26 != null)
                            if (int.Parse(it.ngay26.Split('-')[4]) < int.Parse(item.ngay26.Split('-')[6]) && int.Parse(it.ngay26.Split('-')[6]) > int.Parse(item.ngay26.Split('-')[4])
                              || int.Parse(it.ngay26.Split('-')[4]) == int.Parse(item.ngay26.Split('-')[6]) && int.Parse(it.ngay26.Split('-')[5]) < int.Parse(item.ngay26.Split('-')[7])
                              || int.Parse(it.ngay26.Split('-')[6]) == int.Parse(item.ngay26.Split('-')[4]) && int.Parse(it.ngay26.Split('-')[7]) > int.Parse(item.ngay26.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay26.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay27 != null && item.ngay27 != null)
                            if (int.Parse(it.ngay27.Split('-')[4]) < int.Parse(item.ngay27.Split('-')[6]) && int.Parse(it.ngay27.Split('-')[6]) > int.Parse(item.ngay27.Split('-')[4])
                              || int.Parse(it.ngay27.Split('-')[4]) == int.Parse(item.ngay27.Split('-')[6]) && int.Parse(it.ngay27.Split('-')[5]) < int.Parse(item.ngay27.Split('-')[7])
                              || int.Parse(it.ngay27.Split('-')[6]) == int.Parse(item.ngay27.Split('-')[4]) && int.Parse(it.ngay27.Split('-')[7]) > int.Parse(item.ngay27.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay27.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay28 != null && item.ngay28 != null)
                            if (int.Parse(it.ngay28.Split('-')[4]) < int.Parse(item.ngay28.Split('-')[6]) && int.Parse(it.ngay28.Split('-')[6]) > int.Parse(item.ngay28.Split('-')[4])
                              || int.Parse(it.ngay28.Split('-')[4]) == int.Parse(item.ngay28.Split('-')[6]) && int.Parse(it.ngay28.Split('-')[5]) < int.Parse(item.ngay28.Split('-')[7])
                              || int.Parse(it.ngay28.Split('-')[6]) == int.Parse(item.ngay28.Split('-')[4]) && int.Parse(it.ngay28.Split('-')[7]) > int.Parse(item.ngay28.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay28.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay29 != null && item.ngay29 != null)
                            if (int.Parse(it.ngay29.Split('-')[4]) < int.Parse(item.ngay29.Split('-')[6]) && int.Parse(it.ngay29.Split('-')[6]) > int.Parse(item.ngay29.Split('-')[4])
                              || int.Parse(it.ngay29.Split('-')[4]) == int.Parse(item.ngay29.Split('-')[6]) && int.Parse(it.ngay29.Split('-')[5]) < int.Parse(item.ngay29.Split('-')[7])
                              || int.Parse(it.ngay29.Split('-')[6]) == int.Parse(item.ngay29.Split('-')[4]) && int.Parse(it.ngay29.Split('-')[7]) > int.Parse(item.ngay29.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay29.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay30 != null && item.ngay30 != null)
                            if (int.Parse(it.ngay30.Split('-')[4]) < int.Parse(item.ngay30.Split('-')[6]) && int.Parse(it.ngay30.Split('-')[6]) > int.Parse(item.ngay30.Split('-')[4])
                              || int.Parse(it.ngay30.Split('-')[4]) == int.Parse(item.ngay30.Split('-')[6]) && int.Parse(it.ngay30.Split('-')[5]) < int.Parse(item.ngay30.Split('-')[7])
                              || int.Parse(it.ngay30.Split('-')[6]) == int.Parse(item.ngay30.Split('-')[4]) && int.Parse(it.ngay30.Split('-')[7]) > int.Parse(item.ngay30.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay30.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                        if (it.ngay31 != null && item.ngay31 != null)
                            if (int.Parse(it.ngay31.Split('-')[4]) < int.Parse(item.ngay31.Split('-')[6]) && int.Parse(it.ngay31.Split('-')[6]) > int.Parse(item.ngay31.Split('-')[4])
                              || int.Parse(it.ngay31.Split('-')[4]) == int.Parse(item.ngay31.Split('-')[6]) && int.Parse(it.ngay31.Split('-')[5]) < int.Parse(item.ngay31.Split('-')[7])
                              || int.Parse(it.ngay31.Split('-')[6]) == int.Parse(item.ngay31.Split('-')[4]) && int.Parse(it.ngay31.Split('-')[7]) > int.Parse(item.ngay31.Split('-')[5])
                        )
                        {
                            var ngay = it.ngay31.Split('-');
                            TempData["testmsg"] = "Đăng lý lớp "+item.LopHoc.tenLopHoc+" không thành công vì lịch học đã bị trùng tại ngày " + ngay[1] + "-" + ngay[2] + "-" + ngay[3] + ".";
                            return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
                        }
                       

                    }
                }
                
            }
           
            var dslh = new DSLopHoc();
            dslh.idHV = hv.id;
            dslh.idLH = lophoc.ID;
            dslh.ngaydDangKy = DateTime.Now;
            int kt = 0;
            try
            {
                var daotb = new ThongBaoDAO();
                var tb = new ThongBao();
                tb.icon = "fa fa-address-card";
                tb.ngay = DateTime.Now;
                tb.trangThai = 0;
                tb.idTK = lophoc.Giangvien.TaiKhoan.iD;
                tb.link = "http://localhost:52790/GiaoVien/QLLopHoc/"+lophoc.ID;
                tb.noiDung = hv.TaiKhoan.hovaten +" đã đăng ký vào lớp học " + lophoc.tenLopHoc;
                daotb.Insert(tb);
                kt = dao.Insert(dslh);
            }
            catch (Exception ex)
            {
                TempData["testmsg"] = "Có lỗi trong quá trình đăng ký. Vui lòng thử lại sau";
                return RedirectToAction("chitietlophoc/" + lophoc.ID, "Tim");
            }
            
            if(kt != 0)
            {
                TempData["testmsg"] = "Đăng ký thành công";
                return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
            }
            else
            {
                TempData["testmsg"] = "Có lỗi trong quá trình đăng ký. Vui lòng thử lại sau";
                return RedirectToAction("chitietlophoc/"+ lophoc.ID, "Tim");
            }
            //1 - 15 - 4 - 2021 - 9 - 00 - 11 - 30    2
            //1 - 15 - 4 - 2021 - 11 - 30 - 12 - 30    3
            //0   1    2    3     4   5    6     7

        }

    }
}