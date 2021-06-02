namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSLopHoc")]
    public partial class DSLopHoc
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idHV { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idLH { get; set; }

        public DateTime ngaydDangKy { get; set; }

        public int? danhgia { get; set; }

        [Column(TypeName = "ntext")]
        public string binhluan { get; set; }

        public DateTime? ngayDanhGia { get; set; }

        public int? trangthai { get; set; }

        public virtual HocVien HocVien { get; set; }

        public virtual LopHoc LopHoc { get; set; }
    }
}
