using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class LichSuGDDAO
    {
        WebEngDbContext db = null;
        public LichSuGDDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(LichSuGD entity)
        {
            db.LichSuGDs.Add(entity);
            db.SaveChanges();
            return entity.iD;
        }

        public bool Update(LichSuGD entity)
        {
            try
            {
                var gd = db.LichSuGDs.Find(entity.iD);
                gd.TenGD = entity.TenGD;
                
                db.SaveChanges(); 
                return true;
            }catch( Exception ex)
            {
                return false;
            }
        }
      
        public IEnumerable<LichSuGD> FindAll()
        {
            return db.LichSuGDs;
        }

        public LichSuGD FindByID(int id)
        {
            return db.LichSuGDs.Find(id);
        }

      

        public IEnumerable<LichSuGD> FindByTDN(string tdn)
        {
            return db.LichSuGDs.Where(x => x.ViTien.TaiKhoan.tenDangNhap == tdn);           
           
        }
    }
}
