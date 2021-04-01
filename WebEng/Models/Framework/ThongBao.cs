namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongBao")]
    public partial class ThongBao
    {
        public int ID { get; set; }

        public int? idTK { get; set; }

        [Column(TypeName = "text")]
        public string noiDung { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
