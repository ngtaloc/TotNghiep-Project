using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class DSLopHocDAO
    {
        WebEngDbContext db = null;
        public DSLopHocDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(DSLopHoc entity)
        {
            try
            {

                db.DSLopHocs.Add(entity);
                db.SaveChanges();
                return entity.idLH;
            }
            catch
            {
                return 0;
            }
            
        }
        public DSLopHoc GetByID(int idlh, int idhv)
        {
            return db.DSLopHocs.FirstOrDefault(x=>x.idHV==idhv && x.idLH==idlh);
        }
        public bool Update(DSLopHoc entity)
        {
            var dslh = this.GetByID(entity.idLH,entity.idHV);
            dslh.danhgia = entity.danhgia;
            dslh.binhluan = entity.binhluan;
            //dslh.ngayDanhGia = entity.ngayDanhGia;
            db.SaveChanges();
            return true;
        }
        public bool UpdateStatus(DSLopHoc entity)
        {
            var dslh = this.GetByID(entity.idLH, entity.idHV);
            dslh.trangthai = entity.trangthai;
            //dslh.ngayDanhGia = entity.ngayDanhGia;
            db.SaveChanges();
            return true;
        }


        public IEnumerable<DSLopHoc> FindAll()
        {
            return db.DSLopHocs;
        }

       public bool HocVienInLopHoc(int idhv, int idlh)
        {
            if (db.DSLopHocs.Where(x=>x.idHV==idhv && x.idLH == idlh).Count() > 0)
            {
                return true;
            }
            return false;
        }
        
    }
}
