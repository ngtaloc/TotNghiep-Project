using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class TietHocDAO
    {
        WebEngDbContext db = null;
        public TietHocDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(TietHoc entity)
        {
            db.TietHocs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(TietHoc entity)
        {
            try
            {
                var gv = db.TietHocs.Find(entity.ID);
                
                db.SaveChanges(); 
                return true;
            }catch( Exception ex)
            {
                return false;
            }
        }
      
        public IEnumerable<TietHoc> FindAll()
        {
            return db.TietHocs;
        }

        public TietHoc GetByID(int id)
        {
            return db.TietHocs.Find(id);
        }

       public bool Delete(int id)
        {
            try
            {
                var item = db.TietHocs.Find(id);
                db.TietHocs.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }


        public IEnumerable<TietHoc> FindByLopHoc(int idLh)
        {   
            return db.TietHocs.Where(x => x.idLopHoc == idLh);
        }

        //public IEnumerable<TietHoc> FindTietHocByTDN(string tdn)
        //{
        //    var dsLopHoc = db.TaiKhoans.FirstOrDefault(x => x.tenDangNhap == tdn).HocViens.FirstOrDefault().DSLopHocs;
        //    IEnumerable<TietHoc> tiethoc;
        //    foreach (var item in dsLopHoc)
        //    {
        //        item.LopHoc.Ngays
        //    }
                
        //}
    }
}
