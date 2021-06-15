using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models.DAO
{
    public class HocVienDAO
    {
        WebEngDbContext db = null;
        public HocVienDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(HocVien entity)
        {
            //db.TaiKhoans.Add(entity.TaiKhoan);
            db.HocViens.Add(entity);
            
            //db.TAIKHOAN_NHOMQUYEN.Add(entity.TaiKhoan.TAIKHOAN_NHOMQUYEN);
            db.SaveChanges();
            return entity.id;
        }

        public IEnumerable<HocVien> listAll()
        {
            return db.HocViens;
        }

        public HocVien GetByID(int id)
        {
            return db.HocViens.SingleOrDefault(x => x.id == id);
        }

        public HocVien FindByTDN(string tdn)
        {
            return db.HocViens.FirstOrDefault(x => x.TaiKhoan.tenDangNhap == tdn);
        }


        public bool Update(HocVien entity, string tdn)
        {
            try
            {
                var hv = this.FindByTDN(tdn);
                hv.TaiKhoan.hovaten = entity.TaiKhoan.hovaten;
                hv.gioitinh = entity.gioitinh;
                hv.ngaysinh = entity.ngaysinh;
                hv.email = entity.email;
                hv.diachi = entity.diachi;
                hv.sdt = entity.sdt;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Khoa(int id)
        {
            try
            {
                var hocVien = db.HocViens.Find(id);
                if (hocVien.TaiKhoan.trangThai == 0)
                {
                    hocVien.TaiKhoan.trangThai = 1;
                }
                else
                if (hocVien.TaiKhoan.trangThai == 1)
                {
                    hocVien.TaiKhoan.trangThai = 0;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<HocVien> FindAll()
        {
            return db.HocViens;
        }

        public IEnumerable<HocVien> Tim(string tim)
        {
            return db.HocViens.Where(x => x.email.Contains(tim) || x.diachi.Contains(tim)
            || x.sdt.Contains(tim) || x.gioitinh.Contains(tim) || x.TaiKhoan.hovaten.Contains(tim));
        }
    }
}
