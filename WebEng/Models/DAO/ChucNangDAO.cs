using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class ChucNangDAO
    {
        WebEngDbContext db = null;
        public ChucNangDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(ChucNang entity)
        {
            db.ChucNangs.Add(entity);
            db.SaveChanges();
            return entity.iD;
        }

        public bool Update(ChucNang entity)
        {
            try
            {
                var gv = db.ChucNangs.Find(entity.iD);
                gv.tenChucNang = entity.tenChucNang;
               
                db.SaveChanges(); 
                return true;
            }catch( Exception ex)
            {
                return false;
            }
        }
      
        public IEnumerable<ChucNang> FindAll()
        {
            return db.ChucNangs;
        }

        public Giangvien GetByID(int id)
        {
            return db.Giangviens.Find(id);
        }

       public bool Delete(int id)
        {
            try
            {
                var chucnang = db.ChucNangs.Find(id);
                db.ChucNangs.Remove(chucnang);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        
    }
}
