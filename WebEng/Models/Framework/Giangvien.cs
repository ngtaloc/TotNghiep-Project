namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Giangvien")]
    public partial class Giangvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Giangvien()
        {
            KyNangGiangViens = new HashSet<KyNangGiangVien>();
            LopHocs = new HashSet<LopHoc>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string diachi { get; set; }

        [StringLength(3)]
        public string gioitinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysinh { get; set; }

        [Column(TypeName = "ntext")]
        public string gioithieu { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(10)]
        public string sdt { get; set; }

        public int idTK { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KyNangGiangVien> KyNangGiangViens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHoc> LopHocs { get; set; }
    }
}
