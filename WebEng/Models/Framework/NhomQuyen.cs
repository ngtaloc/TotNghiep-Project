namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomQuyen")]
    public partial class NhomQuyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhomQuyen()
        {
            TAIKHOAN_NHOMQUYEN = new HashSet<TAIKHOAN_NHOMQUYEN>();
            ChucNangs = new HashSet<ChucNang>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string tenNhomQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAIKHOAN_NHOMQUYEN> TAIKHOAN_NHOMQUYEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChucNang> ChucNangs { get; set; }
    }
}
