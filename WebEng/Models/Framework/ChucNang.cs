namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChucNang")]
    public partial class ChucNang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChucNang()
        {
            ChucNang1 = new HashSet<ChucNang>();
            TAIKHOAN_NHOMQUYEN = new HashSet<TAIKHOAN_NHOMQUYEN>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iD { get; set; }

        [Required]
        [StringLength(50)]
        public string tenChucNang { get; set; }

        [StringLength(128)]
        public string tenFile { get; set; }

        [StringLength(50)]
        public string icon { get; set; }

        public int? iDCha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChucNang> ChucNang1 { get; set; }

        public virtual ChucNang ChucNang2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAIKHOAN_NHOMQUYEN> TAIKHOAN_NHOMQUYEN { get; set; }
    }
}
