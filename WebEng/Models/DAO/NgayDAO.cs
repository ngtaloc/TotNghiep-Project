using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class NgayDAO
    {
        WebEngDbContext db = null;
        public NgayDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(Ngay entity)
        {
            db.Ngays.Add(entity);
            db.SaveChanges();
            return entity.iD;
        }

        public bool Update(Ngay entity)
        {
            try
            {
                var gv = db.Ngays.Find(entity.iD);
                gv.nam = entity.nam;
               
                db.SaveChanges(); 
                return true;
            }catch( Exception ex)
            {
                return false;
            }
        }
      
        public IEnumerable<Ngay> FindAll()
        {
            return db.Ngays;
        }

        public Ngay GetByID(int id)
        {
            return db.Ngays.Find(id);
        }

       public bool Delete(int id)
        {
            try
            {
                var item = db.Ngays.Find(id);
                db.Ngays.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public IEnumerable<Ngay> FindByTDN(string tdn)
        {

            //var vd = db.Database.SqlQuery<IEnumerable<Ngay>>("select * from (((Ngay n join LopHoc lh on n.iDLopHoc=lh.ID) join DSLopHoc dslh on lh.ID = dslh.idLH) join HocVien hv on dslh.idHV = hv.id ) join TaiKhoan tk on hv.idTK=tk.iD where tk.tenDangNhap='hv'");

            var j = (from n in db.Ngays
                     join lh in db.LopHocs on n.iDLopHoc equals lh.ID
                     join dslh in db.DSLopHocs on lh.ID equals dslh.idLH
                     join hv in db.HocViens on dslh.idHV equals hv.id
                     join tk in db.TaiKhoans on hv.idTK equals tk.iD
                     where tk.tenDangNhap == tdn
                     select n);

            //var dsLopHoc = db.TaiKhoans.FirstOrDefault(x => x.tenDangNhap == tdn).HocViens.FirstOrDefault().DSLopHocs;
            //var ds = db.DSLopHocs.Where(y => y.HocVien.TaiKhoan.tenDangNhap==tdn);
            return j;
        }

        public IEnumerable<Ngay> FindByTDNGV(string tdn)
        {

            //var vd = db.Database.SqlQuery<IEnumerable<Ngay>>("select * from (((Ngay n join LopHoc lh on n.iDLopHoc=lh.ID) join DSLopHoc dslh on lh.ID = dslh.idLH) join HocVien hv on dslh.idHV = hv.id ) join TaiKhoan tk on hv.idTK=tk.iD where tk.tenDangNhap='hv'");

            var j = (from n in db.Ngays
                     join lh in db.LopHocs on n.iDLopHoc equals lh.ID
                     join gv in db.Giangviens on lh.idGV equals gv.ID
                     join tk in db.TaiKhoans on gv.idTK equals tk.iD
                     where tk.tenDangNhap == tdn
                     select n);

            //var dsLopHoc = db.TaiKhoans.FirstOrDefault(x => x.tenDangNhap == tdn).HocViens.FirstOrDefault().DSLopHocs;
            //var ds = db.DSLopHocs.Where(y => y.HocVien.TaiKhoan.tenDangNhap==tdn);
            return j;
        }

        public IEnumerable<Ngay> FindByLopHoc(int idlh)
        {
            return db.Ngays.Where(x => x.iDLopHoc == idlh);
        }
    }
}
