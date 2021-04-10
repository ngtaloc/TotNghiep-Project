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
        
    }
}
