using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Models.Framework;
using Models.DAO;

namespace WebEng.Areas.GiaoVien.Controllers
{
    public class NgheController : Controller
    {
        // GET: GiaoVien/Nghe
        public ActionResult Index()
        {

            return View();
        }
        //Tạo phương thức hành động UploadAudio với [HttpGet] trong bộ điều khiển.
        //Viết đoạn mã sau để lấy dữ liệu từ bảng cơ sở dữ liệu.
        [HttpGet]
        public ActionResult UploadAudio(int id = 1)
        {
            //List<TaiLieu> audiolist = new List<TaiLieu>();
            var lh = new LopHocDAO().GetByID(id);
            //string CS = ConfigurationManager.ConnectionStrings["WebEngDbContext"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(CS))
            //{
            //    
            //    SqlCommand cmd = new SqlCommand("spGetAllAudioFile", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    con.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();
            //    while (rdr.Read())
            //    {
            //        TaiLieu audio = new TaiLieu();
            //        audio.ID = Convert.ToInt32(rdr["ID"]);
            //        audio.ten = rdr["ten"].ToString();
            //        audio.FileSize = Convert.ToInt32(rdr["FileSize"]);
            //        audio.link = rdr["link"].ToString();
            //        audio.LopHoc = lh;
            //        audio.TaiKhoan = lh.Giangvien.TaiKhoan;                   
            //        audiolist.Add(audio);
            //    }
            //}
            ViewBag.lophoc = lh;
            var audiolist = lh.TaiLieux.Where(x => x.TaiKhoan.tenDangNhap == User.Identity.Name);
            return View(audiolist);
        }
        //Tạo phương thức hành động UploadAudio với [HttpPost] trong bộ điều khiển. 
        //Viết đoạn mã sau để chèn dữ liệu vào cơ sở dữ liệu và tải tệp lên trong thư mục AudioFileUpload của dự án.
        [HttpPost]
        public ActionResult UploadAudio(HttpPostedFileBase fileupload, LopHoc lh)
        {
            if (fileupload != null)
            {
                string fileName = Path.GetFileName(fileupload.FileName);
                int fileSize = fileupload.ContentLength;
                int Size = fileSize / 1000000;
                fileupload.SaveAs(Server.MapPath("~/" + fileName));

                //string CS = ConfigurationManager.ConnectionStrings["WebEngDbContext"].ConnectionString;
                //using (SqlConnection con = new SqlConnection(CS))
                //{
                //    SqlCommand cmd = new SqlCommand("spAddNewAudioFile", con);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    con.Open();
                //    cmd.Parameters.AddWithValue("@ten", fileName);
                //    cmd.Parameters.AddWithValue("@FileSize", Size);
                //    cmd.Parameters.AddWithValue("link", "~/" + fileName);
                //    cmd.ExecuteNonQuery();
                //}
                var dao = new TaiLieuDAO();
                var tailieu = new TaiLieu();
                tailieu.link = fileName;
                tailieu.FileSize = fileSize;
                tailieu.ten = fileName;
                
                dao.Insert(tailieu);
            }
            return RedirectToAction("UploadAudio");
        }
    }
}