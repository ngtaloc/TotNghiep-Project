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

namespace WebEng.Controllers
{
    public class DangKyController : Controller
    {
        // GET: DangKy
        
        [HttpGet]
        public ActionResult DKHocVien()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DKHocVien(HocVien hocVien,TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                var daoHV = new HocVienDAO();
                var daoTK = new TaiKhoanDAO();
                taiKhoan.ngayDangKy = DateTime.Now;
                int idtk = daoTK.Insert(taiKhoan);
                int idhv = daoHV.Insert(hocVien);
                if (idhv > 0)
                {
                    ModelState.AddModelError("", "Đăng ký học viên thành công");
                }
                else
                {
                    return RedirectToAction("DKHocVien", "DangKy");
        
                }
            }
            return View("DKHocVien");
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TaiKhoan taiKhoan, string name, string diachi, string gioitinh, string ngaysinh, string email, string sdt, string optradio, int lvListening=-1, int lvSpeaking=-1, int lvReading=-1, int lvWriting=-1, bool lis = false, bool spe = false, bool rea = false, bool wri = false, bool agree = false )
        {
            if (ModelState.IsValid && agree)
            {
               if(optradio== "GiaoVien")
                {
                    var dao = new GiangVienDAO();
                    Giangvien gv = new Giangvien();
                    var md5pass = EncryptorMD5.MD5Hash(taiKhoan.matKhau);
                    taiKhoan.matKhau = md5pass;
                    taiKhoan.trangThai = 1;
                    var quyen = new TAIKHOAN_NHOMQUYEN();
                    quyen.TaiKhoan = taiKhoan;
                    quyen.IDNHOMQUYEN = 2; //2 là quyền giáo viên
                    taiKhoan.TAIKHOAN_NHOMQUYEN.Add(quyen);
                    gv.TaiKhoan = taiKhoan;
                    gv.TaiKhoan.hovaten = name;
                    gv.diachi = diachi;
                    gv.gioitinh = gioitinh;
                    if (ngaysinh != "")
                        gv.ngaysinh = DateTime.Parse(ngaysinh);
                    gv.email = email;
                    gv.sdt = sdt;
                    

                    if (lis)
                    {
                        var kngv = new KyNangGiangVien();
                        kngv.idGV = gv.ID;
                        kngv.idKN = 1;
                        kngv.idCD = lvListening;
                        gv.KyNangGiangViens.Add(kngv);
                    }
                    if (spe)
                    {
                        var kngv = new KyNangGiangVien();
                        kngv.idGV = gv.ID;
                        kngv.idKN = 2;
                        kngv.idCD = lvSpeaking;
                        gv.KyNangGiangViens.Add(kngv);
                    }
                    if (rea)
                    {
                        var kngv = new KyNangGiangVien();
                        kngv.idGV = gv.ID;
                        kngv.idKN = 3;
                        kngv.idCD = lvReading;
                        gv.KyNangGiangViens.Add(kngv);
                    }
                    if (wri)
                    {
                        var kngv = new KyNangGiangVien();
                        kngv.idGV = gv.ID;
                        kngv.idKN = 4;
                        kngv.idCD = lvWriting;
                        gv.KyNangGiangViens.Add(kngv);
                    }
                    try
                    {
                        dao.Insert(gv);
                        ModelState.AddModelError("", "Đăng ký giáo viên thành công");
                        return RedirectToAction("DangKyThanhCong", "DangKy", gv.TaiKhoan);
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", "Lỗi đăng ký giáo viên: " + e.ToString());
                    }
                }
                else
               if(optradio== "HocVien")
                {
                    var dao = new HocVienDAO();
                    var hv = new HocVien();
                    var md5pass = EncryptorMD5.MD5Hash(taiKhoan.matKhau);
                    taiKhoan.matKhau = md5pass;
                    taiKhoan.trangThai = 1;
                    taiKhoan.face = -1;
                    taiKhoan.ngayDangKy = DateTime.Now;
                    var quyen = new TAIKHOAN_NHOMQUYEN();
                    quyen.TaiKhoan = taiKhoan;
                    quyen.IDNHOMQUYEN = 3; //3 là quyền học viên
                    taiKhoan.TAIKHOAN_NHOMQUYEN.Add(quyen);
                    hv.TaiKhoan = taiKhoan;
                    hv.TaiKhoan.hovaten = name;
                    hv.diachi = diachi;
                    hv.gioitinh = gioitinh;
                    if(ngaysinh!="")
                        hv.ngaysinh = DateTime.Parse(ngaysinh);
                    hv.email = email;
                    hv.sdt = sdt;
                    try
                    {
                        dao.Insert(hv);
                        ModelState.AddModelError("", "Đăng ký học viên thành công");
                        return RedirectToAction("DangKyThanhCong", "DangKy", hv.TaiKhoan);

                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", "Lỗi đăng ký học viên: " + e.Message);
                        
                    }
                }
              
            }
            else
            {
                if(!agree) ModelState.AddModelError("", "Hãy chấp nhận các điều khoản của chúng tôi");
                ModelState.AddModelError("", "Thông tin đăng ký không đúng yêu cầu");
            }
            return View("Index");
        }
    
        [HttpGet]
        public ActionResult DangKyThanhCong(TaiKhoan tk)
        {
            return View(tk);
        }
        [HttpPost]
        public ActionResult DangKyThanhCong(int id)
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

                // write the output we got from python app 
                Console.WriteLine("Value received from script: " + myString);
                ModelState.AddModelError("", "Có lỗi trong quá trình quét mặt: " + myString);

            }
            catch (Exception e)
            {
                tk = dao.SetFaceByID(id);
                ModelState.AddModelError("", "Có lỗi trong quá trình quét mặt. Vui lòng thử lại: " + e.ToString());

            }
            return View(tk);
        }

    }
}