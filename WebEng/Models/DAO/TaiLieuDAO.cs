using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class TaiLieuDAO
    {
        WebEngDbContext db = null;
        public TaiLieuDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(TaiLieu entity)
        {
            db.TaiLieux.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(TaiLieu entity)
        {
            try
            {
                var tl = db.TaiLieux.Find(entity.ID);
                tl.link = entity.link;
                tl.ten = entity.ten;
                tl.moTa = entity.moTa;
                tl.trangThai = entity.trangThai;
               
                db.SaveChanges(); 
                return true;
            }catch( Exception ex)
            {
                return false;
            }
        }
      
        public IEnumerable<TaiLieu> FindAll()
        {
            return db.TaiLieux;
        }

        public TaiLieu GetByID(int id)
        {
            return db.TaiLieux.Find(id);
        }

       public bool Delete(int id)
        {
            try
            {
                var item = db.TaiLieux.Find(id);
                db.TaiLieux.Remove(item);
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
