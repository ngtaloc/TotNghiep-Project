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
            BinhLuan = new HashSet<BinhLuan>();
            DSLopHoc = new HashSet<DSLopHoc>();
            KyNangLopHoc = new HashSet<KyNangLopHoc>();
            TaiLieu = new HashSet<TaiLieu>();
            TietHoc = new HashSet<TietHoc>();
            ThoiKhoaBieu = new HashSet<ThoiKhoaBieu>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string tenLopHoc { get; set; }

        [Column(TypeName = "text")]
        public string mota { get; set; }

        public int? soluong { get; set; }

        [StringLength(50)]
        public string yeucau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayBegin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayEnd { get; set; }

        public int? soBuoi { get; set; }

        [StringLength(50)]
        public string trangThai { get; set; }

        public int? idGV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSLopHoc> DSLopHoc { get; set; }

        public virtual Giangvien Giangvien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KyNangLopHoc> KyNangLopHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiLieu> TaiLieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TietHoc> TietHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThoiKhoaBieu> ThoiKhoaBieu { get; set; }
    }
}
