namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichSuGD")]
    public partial class LichSuGD
    {
        public int iD { get; set; }

        public DateTime ThoiGiangGD { get; set; }

        [StringLength(200)]
        public string TenGD { get; set; }

        public int? LoaiGD { get; set; }

        public int SoTienGD { get; set; }

        public int? idVT { get; set; }

        public virtual ViTien ViTien { get; set; }
    }
}
