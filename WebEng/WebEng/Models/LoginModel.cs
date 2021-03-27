using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEng.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời bạn nhập tên đăng nhập")]
        public string userName { set; get; }
        [Required(ErrorMessage = "Mời bạn nhập mật khẩu")]
        public string passWord { set; get; }
        public bool rememberMe { set; get; }
    }
}