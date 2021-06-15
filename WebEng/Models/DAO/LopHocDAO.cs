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
        public void upload()
        {
            var listlh = db.LopHocs;
            foreach (var item in listlh)
            {
                string begin = item.ngayBegin.ToString();
                if (!string.IsNullOrEmpty(begin))
                {
                    if (DateTime.Compare(DateTime.Parse(begin), DateTime.Now) <= 0 && item.trangThai < 2)
                    {
                        item.trangThai = 2;
                        
                    }
                }
            }
            db.SaveChanges();
        }
        public bool Update(LopHoc entity)
        {
            try
            {
                var lh = db.LopHocs.Find(entity.ID);
                lh.tenLopHoc = entity.tenLopHoc;
                if (!string.IsNullOrEmpty(entity.hinh)){
                    lh.hinh = entity.hinh;
                }                    
                lh.mota = entity.mota;
                        
                lh.soluong = entity.soluong;
                if (!string.IsNullOrEmpty(entity.soBuoi.ToString())){
                    lh.soBuoi = entity.soBuoi;
                }
                lh.trangThai = entity.trangThai;
                lh.yeucau = entity.yeucau;
                
                db.SaveChanges(); 
                return true;
            }catch( Exception ex)
            {
                return false;
            }
        }

        public int updateAll(LopHoc entity)
        {
            var lh = db.LopHocs.Find(entity.ID);
            lh = entity;
            db.SaveChanges();
            return lh.ID;
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

        public IEnumerable<LopHoc> FindLopHocTim(string tdn, string tim, int tt)
        {
            //return db.TaiKhoans.Where(x => x.tenDangNhap == tdn).First().Giangviens.First().LopHocs;
            return db.LopHocs.Where(x => x.Giangvien.TaiKhoan.tenDangNhap == tdn).Where(y=>y.tenLopHoc.Contains(tim) || y.trangThai ==tt);
        }
        public IEnumerable<LopHoc> FindLopHocGiaoVien(string tdn)
        {
            //return db.TaiKhoans.Where(x => x.tenDangNhap == tdn).First().Giangviens.First().LopHocs;
            return db.LopHocs.Where(x => x.Giangvien.TaiKhoan.tenDangNhap == tdn);
        }
        public IEnumerable<LopHoc> FindLopHocHocVien(string tdn)
        {
            //return db.TaiKhoans.Where(x => x.tenDangNhap == tdn).First().Giangviens.First().LopHocs;
            return db.LopHocs.Where(x => x.DSLopHocs.FirstOrDefault(z=>z.HocVien.TaiKhoan.tenDangNhap == tdn).HocVien.TaiKhoan.tenDangNhap==tdn);
        }

        public IEnumerable<LopHoc> TimLopHoc(string tim)
        {
            return db.LopHocs.Where(x => x.tenLopHoc.Contains(tim) || x.Giangvien.TaiKhoan.hovaten.Contains(tim)
                           || x.KyNangLopHocs.FirstOrDefault(y => y.KyNang.tenKyNang.Contains(tim)) != null);
        }
        public IEnumerable<LopHoc> FindLopHocIndex(string tim, bool Listening, bool Speaking, bool Reading, bool Writing, string lvListening, string lvSpeaking, string lvReading, string lvWriting)
        {

            var enty = db.LopHocs.Where(x => x.tenLopHoc.Contains(tim) || x.Giangvien.TaiKhoan.hovaten.Contains(tim) 
                            || x.KyNangLopHocs.FirstOrDefault(y => y.KyNang.tenKyNang.Contains(tim)) != null);
            //var enty = (from lh in db.LopHocs
            //         join knlh in db.KyNangLopHocs on lh.ID equals knlh.idLH
            //         join kn in db.KyNangs on knlh.idKN equals kn.ID
            //         where (lh.tenLopHoc.Contains(tim) || lh.Giangvien.hovaten.Contains(tim) || 
            //               kn.tenKyNang.Contains(tim))
            //         select lh);
            var t = db.KyNangLopHocs.FirstOrDefault(y => y.KyNang.tenKyNang.Contains("zzzz"));
            foreach (var item in enty) { int a=enty.Count(); }
            
            if (Listening)
            {
                if (lvListening == "0")
                {
                    foreach(var item in enty) { }
                    var lis = (from lh in db.LopHocs
                               join knlh in db.KyNangLopHocs on lh.ID equals knlh.idLH
                               where (knlh.idKN == 1)
                               select lh);
                    foreach (var item in lis) { }
                    enty = from e in enty
                           join l in lis on e.ID equals l.ID
                           select e;
                    foreach (var item in enty) { }
                }
                else
                {
                    int lv = int.Parse(lvListening);
                    var lis = (from lh in db.LopHocs
                               join knlh in db.KyNangLopHocs on lh.ID equals knlh.idLH
                               where knlh.idKN==1 && knlh.idCD ==  lv
                               select lh);
                    enty = from e in enty
                           join l in lis on e.ID equals l.ID
                           select e;
                }
            }
            
            if (Speaking)
            {
                if (lvSpeaking == "0")
                {
                    foreach (var item in enty) { }
                    var spe = (from lh in db.LopHocs
                           join knlh in db.KyNangLopHocs on lh.ID equals knlh.idLH
                           where (knlh.idKN == 2)
                           select lh);
                    foreach(var item in spe) { }
                    enty = from e in enty
                           join l in spe on e.ID equals l.ID
                           select e;
                    foreach (var item in enty) { }
                }
                else
                {
                    int lv = int.Parse(lvSpeaking);

                    var spe = (from lh in db.LopHocs
                           join knlh in db.KyNangLopHocs on lh.ID equals knlh.idLH
                           where knlh.idKN == 2 && knlh.idCD == lv
                           select lh);
                    enty = from e in enty
                           join l in spe on e.ID equals l.ID
                           select e;
                }
            }
            if (Reading)
            {
                if (lvReading == "0")
                {
                    var rea = (from lh in db.LopHocs
                           join knlh in db.KyNangLopHocs on lh.ID equals knlh.idLH
                           where (knlh.idKN == 3)
                           select lh);
                    enty = from e in enty
                           join l in rea on e.ID equals l.ID
                           select e;
                }
                else
                {
                    int lv = int.Parse(lvReading);

                    var rea = (from lh in db.LopHocs
                           join knlh in db.KyNangLopHocs on lh.ID equals knlh.idLH
                           where knlh.idKN == 3 && knlh.idCD == lv
                           select lh);
                    enty = from e in enty
                           join l in rea on e.ID equals l.ID
                           select e;
                }
            }
            if (Writing)
            {
                if (lvWriting == "0")
                {
                    var wri = (from lh in db.LopHocs
                           join knlh in db.KyNangLopHocs on lh.ID equals knlh.idLH
                           where (knlh.idKN == 4)
                           select lh);
                    enty = from e in enty
                           join l in wri on e.ID equals l.ID
                           select e;
                }
                else
                {
                    int lv = int.Parse(lvListening);

                    var wri = (from lh in db.LopHocs
                           join knlh in db.KyNangLopHocs on lh.ID equals knlh.idLH
                           where knlh.idKN == 4 && knlh.idCD == lv
                           select lh);
                    enty = from e in enty
                           join l in wri on e.ID equals l.ID
                           select e;
                }
            }
            return enty;
        }
    }
}
