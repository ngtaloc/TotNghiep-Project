namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiLieu")]
    public partial class TaiLieu
    {
        public int ID { get; set; }

        [Required]
        public string link { get; set; }

        [Column(TypeName = "ntext")]
        public string moTa { get; set; }

        public int? idLoaiTL { get; set; }

        public int? idLH { get; set; }

        public int? idTK { get; set; }

        public virtual LoaiTaiLieu LoaiTaiLieu { get; set; }

        public virtual LopHoc LopHoc { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
