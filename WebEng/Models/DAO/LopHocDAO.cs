using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class LopHocDAO
    {
        WebEngDbContext db = null;
        public LopHocDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(LopHoc entity)
        {
            db.LopHocs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(LopHoc entity)
        {
            try
            {
                var lh = db.LopHocs.Find(entity.ID);
                lh.tenLopHoc = entity.tenLopHoc;
                lh.hinh = entity.hinh;
                lh.mota = entity.mota;
                lh.ngayBegin = entity.ngayBegin;
                lh.ngayEnd = entity.ngayEnd;
                lh.soluong = entity.soluong;
                lh.soBuoi = entity.soBuoi;
                lh.trangThai = entity.trangThai;
                lh.yeucau = entity.yeucau;
                db.SaveChanges(); 
                return true;
            }catch( Exception ex)
            {
                return false;
            }
        }
        public IEnumerable<LopHoc> listAllPageList(int page, int pageSize)
        {
            return db.LopHocs.OrderByDescending(x => x.ID).ToPagedList(page,pageSize);
        }
        public IEnumerable<LopHoc> FindAll()
        {
            return db.LopHocs;
        }
        public LopHoc GetByID(int id)
        {
            return db.LopHocs.Find(id);
        }

       

    }
}
