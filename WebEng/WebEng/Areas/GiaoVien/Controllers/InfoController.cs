using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEng.Common;

namespace WebEng.Areas.GiaoVien.Controllers
{
    [Authorize(Roles = "GiaoVien")]
    public class InfoController : Controller
    {
        // GET: GiaoVien/Info
        
        public ActionResult Index()
        {
            var dao = new GiangVienDAO();
            var model = dao.FindByTDN(User.Identity.Name);
            
            return View(model);
        }
        [HttpPost]
        public ActionResult NapTien(string mang ,string code)
        {
            var gv = new GiangVienDAO().FindByTDN(User.Identity.Name);
            var dao = new LichSuGDDAO();
            if( !(((code.Length ==13 || code.Length ==15) && mang=="Viettel") || (code.Length ==12 && mang== "Mobifone") || ((code.Length == 12 || code.Length == 14) && mang == "Vinaphone")))
            {
                return RedirectToAction("ThongBao","Info", new { mes = "Mã thẻ cào không chính xác vui lòng thử lại." ,type=0} );
            }
            try
            {
                var GD = new LichSuGD();
                GD.idVT = gv.TaiKhoan.ViTiens.FirstOrDefault().iD;
                GD.LoaiGD = 0; //0:nạp; 1:mơ
                GD.SoTienGD = 100000;
                GD.ThoiGiangGD = DateTime.Now;
                string tien = String.Format("{0:#,##0}", GD.SoTienGD);
                GD.TenGD = tien + " VNĐ vào ví tiền bằng thẻ cào " + mang+".";
                

                gv.TaiKhoan.ViTiens.FirstOrDefault().SoDu += 100000;
                gv.TaiKhoan.ViTiens.FirstOrDefault().TongNap += 100000;
                dao.Insert(GD);
                var vt = new ViTienDAO().Update(gv.TaiKhoan.ViTiens.FirstOrDefault());
                
                return RedirectToAction("ThongBao", "Info", new { mes = "Bạn đã nạp thành công " + tien + " VNĐ vào ví của mình." ,type=1});
            }
            catch (Exception ex)
            {
                return RedirectToAction("ThongBao", "Info",new { mes= "Có lỗi trong quá trình nạp: " + ex.Message.ToString(), type=-1});
            }
           
        }
        public ActionResult ThongBao(string mes, int type)
        {
            ViewBag.mes = mes;
            ViewBag.type = type;
            TempData["testmsg"] = mes;

            return View();
        }

        public ActionResult Edit(Giangvien gv , bool Listening = false, bool Speaking = false, bool Reading = false, bool Writing = false, int lvListening =-1, int lvSpeaking = -1, int lvReading = -1, int lvWriting = -1)
        {
            var dao = new GiangVienDAO();
            var giaovien = new Giangvien();
           
            if (Listening)
            {
                var kngv = new KyNangGiangVien();
                kngv.idGV = gv.ID;
                kngv.idKN = 1;
                kngv.idCD = lvListening;
                giaovien.KyNangGiangViens.Add(kngv);
            }
            if (Speaking)
            {
                var kngv = new KyNangGiangVien();
                kngv.idGV = gv.ID;
                kngv.idKN = 2;
                kngv.idCD = lvSpeaking;
                giaovien.KyNangGiangViens.Add(kngv);
            }
            if (Reading)
            {
                var kngv = new KyNangGiangVien();
                kngv.idGV = gv.ID;
                kngv.idKN = 3;
                kngv.idCD = lvReading;
                giaovien.KyNangGiangViens.Add(kngv);
            }
            if (Writing)
            {
                var kngv = new KyNangGiangVien();
                kngv.idGV = gv.ID;
                kngv.idKN = 4;
                kngv.idCD = lvWriting;
                giaovien.KyNangGiangViens.Add(kngv);
            }
            try
            {
                gv.KyNangGiangViens = giaovien.KyNangGiangViens;
                dao.Update(gv,User.Identity.Name);
                TempData["testmsg"] = " Cập nhật thành công ";

                return RedirectToAction("Index", "Info", gv.TaiKhoan);
            }
            catch (Exception e)
            {
                TempData["testmsg"] = "Có lỗi trong quá trình cập nhật: " + e.Message.ToString();

            }
            return RedirectToAction("Index", "Info");
        }


        [HttpGet]
        public ActionResult DoiMK(int ID)
        {
            var model = new TaiKhoanDAO().FindByID(ID);
            return PartialView("DoiMK", model);
        }
        [HttpPost]
        public ActionResult DoiMK(TaiKhoan tk, string matkhau, string matkhaumoi)
        {
            if (tk.matKhau == matkhaumoi)
            {
                tk.matKhau = EncryptorMD5.MD5Hash(matkhaumoi);
                var doi = new TaiKhoanDAO().DoiMK(tk);
                if (doi)
                {
                    TempData["testmsg"] = "Đổi mật khẩu thành công.";
                }
                else
                {
                    TempData["testmsg"] = "Có lỗi trong quá trình Đổi mật khẩu. Vui lòng thử lại sau.";
                }
            }
            else
            {
                TempData["testmsg"] = "Mật khẩu cũ không đúng.";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}