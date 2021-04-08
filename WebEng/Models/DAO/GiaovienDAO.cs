﻿using System;
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

        public bool Update(Giangvien entity)
        {
            try
            {
                var gv = db.Giangvien.Find(entity.ID);
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
            return db.Giangvien.OrderByDescending(x => x.ID).ToPagedList(page,pageSize);
        }
        public IEnumerable<Giangvien> FindAll()
        {
            return db.Giangvien;
        }
        public Giangvien GetByID(int id)
        {
            return db.Giangvien.Find(id);
        }

       

    }
}
