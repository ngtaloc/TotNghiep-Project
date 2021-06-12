using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class fileTraLoiDAO
    {
        WebEngDbContext db = null;
        public fileTraLoiDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(fileTraLoi entity)
        {
            db.fileTraLois.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(fileTraLoi entity)
        {
            try
            {
                var tl = db.fileTraLois.Find(entity.ID);
                tl.ten = entity.ten;
                tl.trangThai = entity.trangThai;             
               
                db.SaveChanges(); 
                return true;
            }catch( Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<fileTraLoi> FindByBT(int idbt)
        {            
            return db.fileTraLois.Where(x=>x.BaiTap.ID==idbt);
        }

        public IEnumerable<fileTraLoi> FindAll()
        {
            return db.fileTraLois;
        }

        public fileTraLoi GetByID(int id)
        {
            return db.fileTraLois.Find(id);
        }

       public bool Delete(int id)
        {
            try
            {
                var item = db.fileTraLois.Find(id);
                db.fileTraLois.Remove(item);
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
