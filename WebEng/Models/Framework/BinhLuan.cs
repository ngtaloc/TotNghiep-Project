namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BinhLuan()
        {
            BinhLuan1 = new HashSet<BinhLuan>();
        }

        public int ID { get; set; }

        public int? idTK { get; set; }

        public int? idLH { get; set; }

        [Column(TypeName = "ntext")]
        public string noiDung { get; set; }

        public DateTime thoiGian { get; set; }

        public int? idCha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuan1 { get; set; }

        public virtual BinhLuan BinhLuan2 { get; set; }

        public virtual LopHoc LopHoc { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
