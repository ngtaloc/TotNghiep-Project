namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fileTraLoi")]
    public partial class fileTraLoi
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string ten { get; set; }

        public int? FileSize { get; set; }

        [Required]
        [StringLength(256)]
        public string link { get; set; }

        public DateTime thoiGian { get; set; }

        public int? trangThai { get; set; }

        public int? idBT { get; set; }

        public int? idHV { get; set; }

        public int? tgLamBai { get; set; }

        public virtual BaiTap BaiTap { get; set; }

        public virtual HocVien HocVien { get; set; }
    }
}
