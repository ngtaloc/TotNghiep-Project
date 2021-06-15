using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class ViTienDAO
    {
        WebEngDbContext db = null;
        public ViTienDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(ViTien entity)
        {
            db.ViTiens.Add(entity);
            db.SaveChanges();
            return entity.iD;
        }

        public bool Update(ViTien entity)
        {
            try
            {
                var gd = db.ViTiens.Find(entity.iD);
                gd.SoDu = entity.SoDu;
                gd.TongNap = entity.TongNap;
                db.SaveChanges(); 
                return true;
            }catch
            {
                return false;
            }
        }
      
        public IEnumerable<ViTien> FindAll()
        {
            return db.ViTiens;
        }

        public ViTien FindByID(int id)
        {
            return db.ViTiens.Find(id);
        }

        public IEnumerable<ViTien> FindByTDN(string tdn)
        {
            return db.ViTiens.Where(x => x.TaiKhoan.tenDangNhap == tdn);           
           
        }
    }
}
