namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TietHoc")]
    public partial class TietHoc
    {
        public int ID { get; set; }

        public int? idTKB { get; set; }

        public int? idLopHoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngay { get; set; }

        public int? buoiHoc { get; set; }

        public int? siso { get; set; }

        public virtual LopHoc LopHoc { get; set; }

        public virtual ThoiKhoaBieu ThoiKhoaBieu { get; set; }
    }
}
