using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using WebEng.Common;
using System.IO;
using System.Diagnostics;

namespace WebEng.Areas.HocVien.Controllers
{
    [Authorize(Roles = "HocVien")]
    public class InfoController : Controller
    {
        // GET: HocVien/Info
        
        public ActionResult Index()
        {
            var dao = new HocVienDAO();
            global::Models.Framework.HocVien model = dao.FindByTDN(User.Identity.Name);
            
            return View(model);
        }
        
        public ActionResult Edit(global::Models.Framework.HocVien hv)
        {
            var dao = new HocVienDAO();
           
            try
            {
                dao.Update(hv,User.Identity.Name);
                TempData["testmsg"] = " Cập nhật thành công ";

                return RedirectToAction("Index", "Info");
            }
            catch (Exception e)
            {
                TempData["testmsg"] = "Có lỗi trong quá trình cập nhật: " + e.Message.ToString();

            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult DoiMK(int ID)
        {
            var model = new TaiKhoanDAO().FindByID(ID);
            return PartialView("DoiMK", model);
        }
        [HttpPost]
        public ActionResult DoiMK(TaiKhoan tk,string matkhau,string matkhaumoi,string reMKmoi)
        {
            if (tk.matKhau == matkhau)
            {
                tk.matKhau = EncryptorMD5.MD5Hash(matkhaumoi);       
                if( matkhaumoi == reMKmoi)
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
        public  ActionResult Upimg(TaiKhoan tk, HttpPostedFileBase img)
        {
            //string fileContent = string.Empty;
            //string fileContentType = string.Empty;
            //byte[] uploadedFile = new byte[img.InputStream.Length];
            //img.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

            //// Initialization.  
            //fileContent = Convert.ToBase64String(uploadedFile);
            //fileContentType = img.ContentType;
            //string filePath = Path.Combine(Server.MapPath("/Temp"), Path.GetFileName(img.FileName));
            if (img != null && img.ContentLength > 0)
            {                
                img.SaveAs(Server.MapPath("~/Content/Data/image/") + img.FileName);
                tk.hinh = "Content/Data/image/" + img.FileName;
                var dao = new TaiKhoanDAO();
                bool kt=dao.upHinhTen(tk);
                if(kt)
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