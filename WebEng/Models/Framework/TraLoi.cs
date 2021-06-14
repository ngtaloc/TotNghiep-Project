namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TraLoi")]
    public partial class TraLoi
    {
        public int ID { get; set; }

        public int? idCauHoi { get; set; }

        public int? idHV { get; set; }

        [StringLength(200)]
        public string DapAn { get; set; }

        public DateTime thoiGian { get; set; }

        public int? tgLamBai { get; set; }

        public virtual CauHoi CauHoi { get; set; }

        public virtual HocVien HocVien { get; set; }
    }
}
