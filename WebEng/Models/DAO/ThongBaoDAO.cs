using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class ThongBaoDAO
    {
        WebEngDbContext db = null;
        public ThongBaoDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(ThongBao entity)
        {
            db.ThongBaos.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(ThongBao entity)
        {
            try
            {
                var gv = db.ThongBaos.Find(entity.ID);
                gv.noiDung = entity.noiDung;
               
                db.SaveChanges(); 
                return true;
            }catch( Exception ex)
            {
                return false;
            }
        }
      
        public IEnumerable<ThongBao> FindAll()
        {
            return db.ThongBaos;
        }

        public ThongBao GetByID(int id)
        {
            return db.ThongBaos.Find(id);
        }

       public bool Delete(int id)
        {
            try
            {
                var item = db.ThongBaos.Find(id);
                db.ThongBaos.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public IEnumerable<ThongBao> FindByTDN(string tdn)
        {

           
            var j = (from tb in db.ThongBaos                     
                     join tk in db.TaiKhoans on tb.idTK equals tk.iD
                     where tk.tenDangNhap == tdn
                     select tb);
            
            return j;
        }
    }
}
