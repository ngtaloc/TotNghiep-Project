using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AccountModel
    {
        private WebEngDbContext context = null;
        public AccountModel()
        {
            context = new WebEngDbContext();
        }

        public bool login(string userName, string passWord)
        { 
            object[] sqlParams =
            {
                new SqlParameter("@userName",userName),
                new SqlParameter("@passWord",passWord),
            };
            var rec = context.Database.SqlQuery<bool>("DangNhap '"+userName+"','"+passWord+"'").SingleOrDefault();
            return rec;
        }
    }
}
