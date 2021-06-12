using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class BaiTapDAO
    {
        WebEngDbContext db = null;
        public BaiTapDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(BaiTap entity)
        {
            db.BaiTaps.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(BaiTap entity)
        {
            try
            {
                var tl = db.BaiTaps.Find(entity.ID);
                tl.ghiChu = entity.ghiChu;
                tl.tenBT = entity.tenBT;
                tl.thoiGianLamBai = entity.thoiGianLamBai;
                tl.ngayNop = entity.ngayNop;
                tl.trangThai = entity.trangThai;
               
                db.SaveChanges(); 
                return true;
            }catch( Exception ex)
            {
                return false;
            }
        }
      
        public IEnumerable<BaiTap> FindAll()
        {
            return db.BaiTaps;
        }

        public BaiTap GetByID(int id)
        {
            return db.BaiTaps.Find(id);
        }

       public bool Delete(int id)
        {
            try
            {
                var item = db.BaiTaps.Find(id);
                db.BaiTaps.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public int CountSubmit(int idbt)
        {
            int tn = db.TraLois.Where(x => x.CauHoi.BaiTap.ID == idbt).GroupBy(x => x.idHV).Count();
            if (tn == 0)
            {
                tn = db.fileTraLois.Where(x => x.BaiTap.ID == idbt).GroupBy(x => x.idHV).Count();
            }
            return tn;
        }


        public IEnumerable<HocVien> ListHV_BT(int idbt)
        {
            return db.HocViens.Where(x => x.TraLois.Where(y => y.CauHoi.BaiTap.ID == idbt).Count() > 0);
        }
    }
}
