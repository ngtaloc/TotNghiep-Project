namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KyNang")]
    public partial class KyNang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KyNang()
        {
            KyNangGiangViens = new HashSet<KyNangGiangVien>();
            KyNangLopHocs = new HashSet<KyNangLopHoc>();
            TaiLieux = new HashSet<TaiLieu>();
            LoaiTaiLieux = new HashSet<LoaiTaiLieu>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string tenKyNang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KyNangGiangVien> KyNangGiangViens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KyNangLopHoc> KyNangLopHocs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiLieu> TaiLieux { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoaiTaiLieu> LoaiTaiLieux { get; set; }
    }
}
