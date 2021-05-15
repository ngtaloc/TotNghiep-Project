using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class BinhLuanDAO
    {
        WebEngDbContext db = null;
        public BinhLuanDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(BinhLuan entity)
        {
            db.BinhLuans.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(BinhLuan entity)
        {
            try
            {
                var gv = db.BinhLuans.Find(entity.ID);
                gv.noiDung = entity.noiDung;
               
                db.SaveChanges(); 
                return true;
            }catch( Exception ex)
            {
                return false;
            }
        }
      
        public IEnumerable<BinhLuan> FindAll()
        {
            return db.BinhLuans;
        }

        public BinhLuan GetByID(int id)
        {
            return db.BinhLuans.Find(id);
        }

       public bool Delete(int id)
        {
            try
            {
                var item = db.BinhLuans.Find(id);
                db.BinhLuans.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public IEnumerable<BinhLuan> FindByTDN(string tdn)
        {           
            var j = (from tb in db.BinhLuans                     
                     join tk in db.TaiKhoans on tb.idTK equals tk.iD
                     where tk.tenDangNhap == tdn
                     select tb);            
            return j;
        }
    }
}
