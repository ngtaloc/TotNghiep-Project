using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class TraLoiDAO
    {
        WebEngDbContext db = null;
        public TraLoiDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(TraLoi entity)
        {
            db.TraLois.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(TraLoi entity)
        {
            try
            {
                var tl = db.TraLois.Find(entity.ID);
                
                db.SaveChanges(); 
                return true;
            }catch( Exception ex)
            {
                return false;
            }
        }

        

        public IEnumerable<TraLoi> FindAll()
        {
            return db.TraLois;
        }

        public TraLoi GetByID(int id)
        {
            return db.TraLois.Find(id);
        }

       public bool Delete(int id)
        {
            try
            {
                var item = db.TraLois.Find(id);
                db.TraLois.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

       public string Diem(int idbt, int idhv)
        {
            var bt = new BaiTapDAO().GetByID(idbt);
            var hv = new HocVienDAO().GetByID(idhv);
            int d = 0;
            foreach(var item in hv.TraLois.Where(x=>x.CauHoi.idBT == bt.ID))
            {
                if (item.DapAn == item.CauHoi.DapAn) d++;
            }
            return d+"/"+bt.CauHois.Count();

        }


    }
}
