namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocVien")]
    public partial class HocVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocVien()
        {
            DSLopHocs = new HashSet<DSLopHoc>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string hovaten { get; set; }

        [StringLength(100)]
        public string diachi { get; set; }

        [StringLength(3)]
        public string gioitinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysinh { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(10)]
        public string sdt { get; set; }

        public int idTK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSLopHoc> DSLopHocs { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
