﻿using System;
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