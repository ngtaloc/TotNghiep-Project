namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CapDo")]
    public partial class CapDo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CapDo()
        {
            KyNangGiangVien = new HashSet<KyNangGiangVien>();
            KyNangLopHoc = new HashSet<KyNangLopHoc>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string tenCapDo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KyNangGiangVien> KyNangGiangVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KyNangLopHoc> KyNangLopHoc { get; set; }
    }
}
