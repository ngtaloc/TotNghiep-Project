using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class GiangVienDAO
    {
        WebEngDbContext db = null;
        public GiangVienDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(Giangvien entity)
        {
            db.Giangviens.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Giangvien entity)
        {
            try
            {
                var gv = db.Giangviens.Find(entity.ID);
                gv.hovaten = entity.hovaten;
                gv.hinh = entity.hinh;
                gv.gioitinh = entity.gioitinh;
                gv.gioithieu = entity.gioithieu;
                gv.ngaysinh = entity.ngaysinh;
                gv.email = entity.email;
                gv.diachi = entity.diachi;
                gv.sdt = entity.sdt;
                db.SaveChanges(); 
                return true;
            }catch( Exception ex)
            {
                return false;
            }
        }
        public IEnumerable<Giangvien> listAllPageList(int page, int pageSize)
        {
            return db.Giangviens.OrderByDescending(x => x.ID).ToPagedList(page,pageSize);
        }
        public IEnumerable<Giangvien> FindAll()
        {
            return db.Giangviens;
        }
        public Giangvien GetByID(int id)
        {
            return db.Giangviens.Find(id);
        }

       public bool Delete(int id)
        {
            try
            {
                var giangvien = db.Giangviens.Find(id);
                db.Giangviens.Remove(giangvien);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool Khoa(int id)
        {
            try
            {
                var giangvien = db.Giangviens.Find(id);
                if(giangvien.TaiKhoan.trangThai == 0)
                {
                    giangvien.TaiKhoan.trangThai = 1;
                }
                else
                if (giangvien.TaiKhoan.trangThai == 1)
                {
                    giangvien.TaiKhoan.trangThai = 0;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Giangvien FindByTDN(string tdn)
        {
            return db.Giangviens.FirstOrDefault(x => x.TaiKhoan.tenDangNhap == tdn);
        }
    }
}
