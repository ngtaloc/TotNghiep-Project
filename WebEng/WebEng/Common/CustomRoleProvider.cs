using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebEng.Common
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        
        public override string[] GetRolesForUser(string username)
        {
            WebEngDbContext db = new WebEngDbContext();
            // tạo biến getrole, so sánh xem UserID đang đăng nhập có giống với tên trong db ko
            TaiKhoan account = null;

            List<string> currentUserRoles = new List<string>();
            try
            {
                account= db.TaiKhoans.Single(x => x.tenDangNhap.Equals(username));
            }
            catch { }
            
            if (account != null) // Nếu giống
            {
                foreach (var i in account.TAIKHOAN_NHOMQUYEN)
                {
                    currentUserRoles.Add(i.NhomQuyen.tenNhomQuyen);
                }
                return currentUserRoles.ToArray();
            }
            else
                return new String[] { };            
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {  
            if (GetRolesForUser(username).Contains(roleName))
            {
                return true;
            }
            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}