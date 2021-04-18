namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TAIKHOAN_NHOMQUYEN
    {
        [Key]
        public int IDTAIKHOANNHOMQUYEN { get; set; }

        public int IDTAIHOAN { get; set; }

        public int IDNHOMQUYEN { get; set; }

        public virtual NhomQuyen NhomQuyen { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
