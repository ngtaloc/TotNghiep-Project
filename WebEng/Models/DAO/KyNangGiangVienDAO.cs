using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models.DAO
{
    public class KyNangGiangVienDAO
    {
        WebEngDbContext db = null;
        public KyNangGiangVienDAO()
        {
            db = new WebEngDbContext();
        }

        public int Insert(KyNangGiangVien entity)
        {
            db.KyNangGiangViens.Add(entity);
            db.SaveChanges();
            return entity.idKN;
        }

        public bool Update(KyNangGiangVien entity)
        {
            try
            {
                var kngv = db.KyNangGiangViens.FirstOrDefault(x=>x.idCD==entity.idCD && x.idGV == entity.idGV && x.idKN == entity.idKN) ;
                kngv.idGV = entity.idGV;
                kngv.idCD = entity.idCD;
                kngv.idKN = entity.idKN;
               
                db.SaveChanges(); 
                return true;
            }catch( Exception ex)
            {
                return false;
            }
        }
       
        public IEnumerable<KyNangGiangVien> FindAll()
        {
            return db.KyNangGiangViens;
        }
        public KyNangGiangVien FindByID(int id)
        {
            return db.KyNangGiangViens.Find(id);
        }

       public bool Delete(int id)
        {
            try
            {
                var KyNangGiangVien = db.KyNangGiangViens.Find(id);
                db.KyNangGiangViens.Remove(KyNangGiangVien);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

      
        public IEnumerable<KyNangGiangVien> FindByTDN(string tdn)
        {
            return db.KyNangGiangViens.Where(x => x.Giangvien.TaiKhoan.tenDangNhap == tdn);
        }
    }
}
