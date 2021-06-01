namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LopHoc")]
    public partial class LopHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LopHoc()
        {
            BinhLuans = new HashSet<BinhLuan>();
            DSLopHocs = new HashSet<DSLopHoc>();
            KyNangLopHocs = new HashSet<KyNangLopHoc>();
            Ngays = new HashSet<Ngay>();
            TaiLieux = new HashSet<TaiLieu>();
            TietHocs = new HashSet<TietHoc>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string tenLopHoc { get; set; }

        [Column(TypeName = "ntext")]
        public string mota { get; set; }

        [Column(TypeName = "text")]
        public string hinh { get; set; }

        public int? soluong { get; set; }

        [StringLength(50)]
        public string yeucau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayBegin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayEnd { get; set; }

        public DateTime ngayDangKy { get; set; }

        public int? soBuoi { get; set; }

        public int? trangThai { get; set; }

        public int? idGV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSLopHoc> DSLopHocs { get; set; }

        public virtual Giangvien Giangvien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KyNangLopHoc> KyNangLopHocs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ngay> Ngays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiLieu> TaiLieux { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TietHoc> TietHocs { get; set; }
    }
}
