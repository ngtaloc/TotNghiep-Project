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
            db.HocVien.Add(entity);
            db.SaveChanges();
            return entity.id;
        }

        public IEnumerable<HocVien> listAll()
        {
            return db.HocVien;
        }

        public HocVien GetByID(int id)
        {
            return db.HocVien.SingleOrDefault(x => x.id == id);
        }

        
        
    }
}
