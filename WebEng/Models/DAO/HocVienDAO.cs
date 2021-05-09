using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models.DAO
{
    public class HocVienDAO
    {
        WebEngDbContext db = null;
        public HocVienDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(HocVien entity)
        {
            db.HocViens.Add(entity);
            db.SaveChanges();
            return entity.id;
        }

        public IEnumerable<HocVien> listAll()
        {
            return db.HocViens;
        }

        public HocVien GetByID(int id)
        {
            return db.HocViens.SingleOrDefault(x => x.id == id);
        }

        public HocVien FindByTDN(string tdn)
        {
            return db.HocViens.FirstOrDefault(x => x.TaiKhoan.tenDangNhap == tdn);
        }
        
    }
}
