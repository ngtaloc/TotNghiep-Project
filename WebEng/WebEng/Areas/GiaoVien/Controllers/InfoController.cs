using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
                TempData["testmsg"] = "Bạn đã nạp thành công " + tien + " VNĐ vào ví của mình.";
                //return RedirectToAction("ThongBao", "Info", new { mes = "Bạn đã nạp thành công " + tien + " VNĐ vào ví của mình." ,type=1});
                return RedirectToAction("Index", "Info");
            }
            catch (Exception ex)
            {
                TempData["testmsg"] = "Có lỗi trong quá trình nạp: " + ex.Message.ToString();
                return RedirectToAction("Index", "Info");
                //return RedirectToAction("ThongBao", "Info",new { mes= "Có lỗi trong quá trình nạp: " + ex.Message.ToString(), type=-1});
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
        public ActionResult DoiMK(TaiKhoan tk, string matkhau, string matkhaumoi, string reMKmoi)
        {
            if (tk.matKhau == matkhau)
            {
                tk.matKhau = EncryptorMD5.MD5Hash(matkhaumoi);
                if (matkhaumoi == reMKmoi)
                {
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
                    TempData["testmsg"] = "Xác nhận lại mật khẩu không đúng.";
                }

            }
            else
            {
                TempData["testmsg"] = "Mật khẩu cũ không đúng.";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Upimg(TaiKhoan tk, HttpPostedFileBase img)
        {
            if (img != null && img.ContentLength > 0)
            {
                img.SaveAs(Server.MapPath("~/Content/Data/image/") + img.FileName);
                tk.hinh = "Content/Data/image/" + img.FileName;
                var dao = new TaiKhoanDAO();
                bool kt = dao.upHinhTen(tk);
                if (kt)
                    TempData["testmsg"] = "Đổi ảnh đại diện thành công.";
                else TempData["testmsg"] = "Có lỗi trong quá trình đổi ảnh đại diện. Vui long thử lại sau.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult FaceTrain(int id)//quét mặt training
        {
            var dao = new TaiKhoanDAO();
            var tk = dao.SetFaceByID(id);
            try
            {

                // full path of python interpreter 
                string python = @"C:\Users\ADMIN\Desktop\khkt\doancn\venv\Scripts\python.exe";

                // python app to call 
                string myPythonApp = @"C:\Users\ADMIN\Desktop\DATN\quoc\TotNghiep-Project\WebEng\WebEng\Python\train.py";



                // Create new process start info 
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

                // make sure we can read the output from stdout 
                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.RedirectStandardOutput = true;

                // start python app with 3 arguments  
                // 1st arguments is pointer to itself,  
                // 2nd and 3rd are actual arguments we want to send 
                //myProcessStartInfo.Arguments = myPythonApp + " " + x + " " + y;
                myProcessStartInfo.Arguments = myPythonApp;
                myProcessStartInfo.WorkingDirectory = @"C:\Users\ADMIN\Desktop\DATN\quoc\TotNghiep-Project\WebEng\WebEng\Python\";


                Process myProcess = new Process();
                // assign start information to the process 
                myProcess.StartInfo = myProcessStartInfo;

                // start the process 
                myProcess.Start();

                // Read the standard output of the app we called.  
                // in order to avoid deadlock we will read output first 
                // and then wait for process terminate: 
                StreamReader myStreamReader = myProcess.StandardOutput;
                string myString = myStreamReader.ReadLine();

                /*if you need to read multiple lines, you might use: 
                    string myString = myStreamReader.ReadToEnd() */

                // wait exit signal from the app we called and then close it. 
                myProcess.WaitForExit();
                myProcess.Close();

                //ModelState.AddModelError("", "Có lỗi trong quá trình quét mặt: " + myString);
                TempData["testmsg"] = "Thêm gương mặt thành công. Bây giờ bạn có thể đăng nhập bằng mặt của mình.";

            }
            catch (Exception e)
            {
                tk = dao.SetFaceByID(id);
                // ModelState.AddModelError("", "Có lỗi trong quá trình quét mặt. Vui lòng thử lại: " + e.ToString());
                TempData["testmsg"] = "Có lỗi trong quá trình quét mặt. Vui lòng thử lại: " + e.ToString();

            }
            return RedirectToAction("Index");
        }
    }
}