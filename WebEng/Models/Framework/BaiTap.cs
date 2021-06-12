namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiTap")]
    public partial class BaiTap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiTap()
        {
            CauHois = new HashSet<CauHoi>();
            fileTraLois = new HashSet<fileTraLoi>();
            TaiLieux = new HashSet<TaiLieu>();
        }

        public int ID { get; set; }

        [StringLength(200)]
        public string tenBT { get; set; }

        public DateTime? ngayNop { get; set; }

        [Column(TypeName = "ntext")]
        public string ghiChu { get; set; }

        public DateTime ngayDang { get; set; }

        public int? trangThai { get; set; }

        public int? thoiGianLamBai { get; set; }

        [Column(TypeName = "ntext")]
        public string tuLuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CauHoi> CauHois { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fileTraLoi> fileTraLois { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiLieu> TaiLieux { get; set; }
    }
}
