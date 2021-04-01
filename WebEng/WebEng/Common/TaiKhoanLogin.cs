using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEng.Common
{
    [Serializable]
    public class TaiKhoanLogin
    {
        public int iDTaiKhoan { set; get; }
        public string userName { set; get; }
        public int quyen { set; get; }
    }
}