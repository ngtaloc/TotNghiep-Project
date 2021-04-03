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
            db.Giangvien.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public IEnumerable<Giangvien> listAllPageList(int page, int pageSize)
        {
            return db.Giangvien.OrderByDescending(x => x.ID).ToPagedList(page,pageSize);
        }

        public Giangvien GetByID(int id)
        {
            return db.Giangvien.SingleOrDefault(x => x.ID == id);
        }



    }
}
