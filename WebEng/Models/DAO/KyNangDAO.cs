using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class KyNangDAO
    {
        WebEngDbContext db = null;
        public KyNangDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(KyNang entity)
        {
            db.KyNangs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(KyNang entity)
        {
            try
            {
                var gv = db.KyNangs.Find(entity.ID);
                gv.tenKyNang = entity.tenKyNang;
                db.SaveChanges(); 
                return true;
            }catch( Exception ex)
            {
                return false;
            }
        }
      
        public IEnumerable<KyNang> FindAll()
        {
            return db.KyNangs;
        }

        public KyNang GetByID(int id)
        {
            return db.KyNangs.Find(id);
        }

       public bool Delete(int id)
        {
            try
            {
                var item = db.KyNangs.Find(id);
                db.KyNangs.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }


        public IEnumerable<TaiLieu> FindByLopHocKN(LopHoc lop, int idkn)
        {
            return db.TaiLieux.Where(x => x.LopHoc.ID == lop.ID && x.idKN==idkn );
        }

    }
}
