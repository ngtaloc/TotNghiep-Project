namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CauHoi")]
    public partial class CauHoi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CauHoi()
        {
            TraLois = new HashSet<TraLoi>();
        }

        public int ID { get; set; }

        public int? idBT { get; set; }

        [Column("CauHoi", TypeName = "ntext")]
        public string CauHoi1 { get; set; }

        [StringLength(200)]
        public string DapAn { get; set; }

        [StringLength(200)]
        public string A { get; set; }

        [StringLength(200)]
        public string B { get; set; }

        [StringLength(200)]
        public string C { get; set; }

        [StringLength(200)]
        public string D { get; set; }

        [StringLength(200)]
        public string E { get; set; }

        public virtual BaiTap BaiTap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TraLoi> TraLois { get; set; }
    }
}
