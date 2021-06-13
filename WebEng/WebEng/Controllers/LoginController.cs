using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebEng.Common;
using WebEng.Models;

namespace WebEng.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                if (Membership.ValidateUser(model.userName, EncryptorMD5.MD5Hash(model.passWord)))
                {
                    //var kt = dao.Login(model.userName, EncryptorMD5.MD5Hash(model.passWord));
                    var user = dao.GetByTDN(model.userName);
                    if(user.trangThai == 0)
                    {
                        
                        ModelState.AddModelError("", "Tài khoản của bạn đã bị khóa!");
                    }
                    else
                    {
                        if (Roles.IsUserInRole(model.userName, "Admin"))
                        {
                            FormsAuthentication.SetAuthCookie(model.userName, model.rememberMe);
                            return RedirectToAction("", "Admin");
                        }
                        else
                        if(Roles.IsUserInRole(model.userName, "GiaoVien"))
                        {
                            FormsAuthentication.SetAuthCookie(model.userName, model.rememberMe);
                            return RedirectToAction("", "GiaoVien");
                        }
                        else
                        {
                            FormsAuthentication.SetAuthCookie(model.userName, model.rememberMe);
                            return RedirectToAction("Index", "HocVien/Tim");
                        }
                            
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu sai!");
                }
            }
            return View("Index");
        }

        
        public ActionResult LoginFace()
        {

            var dao = new TaiKhoanDAO();
            string idtk = null;
            try
            {
                // full path of python interpreter 
                string python = @"C:\Users\ADMIN\Desktop\khkt\doancn\venv\Scripts\python.exe";

                // python app to call 
                string myPythonApp = @"C:\Users\ADMIN\Desktop\DATN\quoc\TotNghiep-Project\WebEng\WebEng\Python\detection.py";

               

                // Create new process start info 
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);

                // make sure we can read the output from stdout 
                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.RedirectStandardOutput = true;
                myProcessStartInfo.RedirectStandardError = true;

                // start python app with 3 arguments  
                // 1st arguments is pointer to itself,  
                // 2nd and 3rd are actual arguments we want to send 
                //myProcessStartInfo.Arguments = myPythonApp + " " + x + " " + y;
                myProcessStartInfo.Arguments = myPythonApp;
                myProcessStartInfo.WorkingDirectory = @"C:\Users\ADMIN\Desktop\DATN\quoc\TotNghiep-Project\WebEng\WebEng\Python\";
                //using (Process process = Process.Start(myProcessStartInfo))
                //{
                //    using (StreamReader reader = process.StandardOutput)
                //    {
                //        string result = reader.ReadToEnd();
                //        ModelState.AddModelError("", "Có lỗi trong quá trình nhận diện. Vui lòng thử lại: " + result);
                //        idtk = result;

                //        process.WaitForExit();
                //        Console.Write(result);

                //    }
                //    string erroi = process.StandardError.ReadToEnd();
                //}
                Process myProcess = new Process();
                // assign start information to the process 
                myProcess.StartInfo = myProcessStartInfo;
                //myProcess.StartInfo.WorkingDirectory = myPythonApp;

                // start the process 
                myProcess.Start();

                // Read the standard output of the app we called.  
                // in order to avoid deadlock we will read output first 
                // and then wait for process terminate: 
                StreamReader myStreamReader = myProcess.StandardOutput;
                string myString = myStreamReader.ReadToEnd();

                /*if you need to read multiple lines, you might use: 
                    string myString = myStreamReader.ReadToEnd() */

                // wait exit signal from the app we called and then close it. 
                myProcess.WaitForExit();
                myProcess.Close();

                idtk = myString;
                // write the output we got from python app 
                Console.WriteLine("Value received from script: " + myString);
                ModelState.AddModelError("", "Có lỗi trong quá trình nhận diệns: " + myString);

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Có lỗi trong quá trình nhận diện. Vui lòng thử lại: " + e.ToString());

            }
            int id = -1;
            try
            {
                id = int.Parse(idtk.Split('\\')[0]);
            }
            catch (Exception e)
            {
                id = -1;
            }
            if(id != -1)
            {
                var user = dao.FindByID(id);
                if (user.trangThai == 0)
                {

                    ModelState.AddModelError("", "Tài khoản của bạn đã bị khóa!");
                }
                else
                {
                    if (Roles.IsUserInRole(user.tenDangNhap, "Admin"))
                    {
                        FormsAuthentication.SetAuthCookie(user.tenDangNhap,false);
                        return RedirectToAction("Index", "Admin/QLGiaoVien", "Admin");
                    }
                    else
                    if (Roles.IsUserInRole(user.tenDangNhap, "GiaoVien"))
                    {
                        FormsAuthentication.SetAuthCookie(user.tenDangNhap, false);
                        return RedirectToAction("", "GiaoVien");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(user.tenDangNhap, false);
                        return RedirectToAction("Index", "HocVien");
                    }

                }
            }
            return View("Index");
        }
      
    }
}