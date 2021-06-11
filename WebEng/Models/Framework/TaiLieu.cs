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

        [StringLength(50)]
        public string ten { get; set; }

        public int? FileSize { get; set; }

        [Required]
        [StringLength(256)]
        public string link { get; set; }

        [Column(TypeName = "ntext")]
        public string moTa { get; set; }

        public DateTime thoiGian { get; set; }

        public int? trangThai { get; set; }

        public int? idKN { get; set; }

        public int? idLH { get; set; }

        public int? idTK { get; set; }

        public int? idBT { get; set; }

        public virtual BaiTap BaiTap { get; set; }

        public virtual KyNang KyNang { get; set; }

        public virtual LopHoc LopHoc { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
