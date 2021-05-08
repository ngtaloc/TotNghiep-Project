namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViTien")]
    public partial class ViTien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ViTien()
        {
            LichSuGDs = new HashSet<LichSuGD>();
        }

        public int iD { get; set; }

        public int? SoDu { get; set; }

        public int? TongNap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }

        public int? idTK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuGD> LichSuGDs { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
