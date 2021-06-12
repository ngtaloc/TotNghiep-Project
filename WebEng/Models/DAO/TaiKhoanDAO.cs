using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models.DAO
{
    public class TaiKhoanDAO
    {
        WebEngDbContext db = null;
        public TaiKhoanDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(TaiKhoan entity)
        {
            db.TaiKhoans.Add(entity);
            db.SaveChanges();
            return entity.iD;
        }
        public bool DoiMK(TaiKhoan entity)
        {
            try
            {
                var tk = db.TaiKhoans.SingleOrDefault(x => x.iD == entity.iD);
                tk.matKhau = entity.matKhau;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool upHinhTen(TaiKhoan entity)
        {
            try
            {
                var tk = db.TaiKhoans.SingleOrDefault(x => x.iD == entity.iD);
                tk.hovaten = entity.hovaten;
                tk.hinh = entity.hinh;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public TaiKhoan GetByTDN(string username)
        {
            return db.TaiKhoans.SingleOrDefault(x => x.tenDangNhap == username);
        }

        public int Login (string username , string password)
        {
            var user = db.TaiKhoans.SingleOrDefault(x => x.tenDangNhap == username && x.matKhau == password);
            if (user == null)
            {
                return -1; //đăng nhập sai
            }
            else
            {
                if (user.trangThai == 0)
                {
                    return 0; //tài khoản bị khóa
                }
                else
                    return 1; //login thành công
            }
        }

        public TaiKhoan FindByID(int id)
        {
            return db.TaiKhoans.SingleOrDefault(x=>x.iD==id);
        }

        public IEnumerable<TaiKhoan> FindAll()
        {
            return db.TaiKhoans;
        }

        public TaiKhoan SetFaceByID(int id)
        {
            var tk = db.TaiKhoans.FirstOrDefault(x => x.iD == id);
            if (tk.face == -1 || tk.face==null)
            {
                tk.face = 0;
            }
            else if (tk.face==0) tk.face = -1;
            db.SaveChanges();
            return tk;
        }
    }
}
