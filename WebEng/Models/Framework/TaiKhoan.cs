namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            BinhLuans = new HashSet<BinhLuan>();
            Giangviens = new HashSet<Giangvien>();
            HocViens = new HashSet<HocVien>();
            TAIKHOAN_NHOMQUYEN = new HashSet<TAIKHOAN_NHOMQUYEN>();
            TaiLieux = new HashSet<TaiLieu>();
            ThongBaos = new HashSet<ThongBao>();
            ViTiens = new HashSet<ViTien>();
        }

        public int iD { get; set; }

        [StringLength(50)]
        public string hovaten { get; set; }

        [Column(TypeName = "text")]
        public string hinh { get; set; }

        [Required]
        [StringLength(50)]
        public string tenDangNhap { get; set; }

        [Required]
        [StringLength(32)]
        public string matKhau { get; set; }

        public DateTime ngayDangKy { get; set; }

        public int? trangThai { get; set; }

        public int? face { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Giangvien> Giangviens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocVien> HocViens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAIKHOAN_NHOMQUYEN> TAIKHOAN_NHOMQUYEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiLieu> TaiLieux { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongBao> ThongBaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ViTien> ViTiens { get; set; }
    }
}
