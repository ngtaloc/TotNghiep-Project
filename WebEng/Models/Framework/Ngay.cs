namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ngay")]
    public partial class Ngay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ngay()
        {
            TietHocs = new HashSet<TietHoc>();
        }

        public int iD { get; set; }

        [StringLength(50)]
        public string ngay1 { get; set; }

        [StringLength(50)]
        public string ngay2 { get; set; }

        [StringLength(50)]
        public string ngay3 { get; set; }

        [StringLength(50)]
        public string ngay4 { get; set; }

        [StringLength(50)]
        public string ngay5 { get; set; }

        [StringLength(50)]
        public string ngay6 { get; set; }

        [StringLength(50)]
        public string ngay7 { get; set; }

        [StringLength(50)]
        public string ngay8 { get; set; }

        [StringLength(50)]
        public string ngay9 { get; set; }

        [StringLength(50)]
        public string ngay10 { get; set; }

        [StringLength(50)]
        public string ngay11 { get; set; }

        [StringLength(50)]
        public string ngay12 { get; set; }

        [StringLength(50)]
        public string ngay13 { get; set; }

        [StringLength(50)]
        public string ngay14 { get; set; }

        [StringLength(50)]
        public string ngay15 { get; set; }

        [StringLength(50)]
        public string ngay16 { get; set; }

        [StringLength(50)]
        public string ngay17 { get; set; }

        [StringLength(50)]
        public string ngay18 { get; set; }

        [StringLength(50)]
        public string ngay19 { get; set; }

        [StringLength(50)]
        public string ngay20 { get; set; }

        [StringLength(50)]
        public string ngay21 { get; set; }

        [StringLength(50)]
        public string ngay22 { get; set; }

        [StringLength(50)]
        public string ngay23 { get; set; }

        [StringLength(50)]
        public string ngay24 { get; set; }

        [StringLength(50)]
        public string ngay25 { get; set; }

        [StringLength(50)]
        public string ngay26 { get; set; }

        [StringLength(50)]
        public string ngay27 { get; set; }

        [StringLength(50)]
        public string ngay28 { get; set; }

        [StringLength(50)]
        public string ngay29 { get; set; }

        [StringLength(50)]
        public string ngay30 { get; set; }

        [StringLength(50)]
        public string ngay31 { get; set; }

        [StringLength(50)]
        public string thu2 { get; set; }

        [StringLength(50)]
        public string thu3 { get; set; }

        [StringLength(50)]
        public string thu4 { get; set; }

        [StringLength(50)]
        public string thu5 { get; set; }

        [StringLength(50)]
        public string thu6 { get; set; }

        [StringLength(50)]
        public string thu7 { get; set; }

        [StringLength(50)]
        public string chunhat { get; set; }

        public int? iDThang { get; set; }

        [StringLength(4)]
        public string nam { get; set; }

        public int? iDLopHoc { get; set; }

        public virtual LopHoc LopHoc { get; set; }

        public virtual Nam Nam1 { get; set; }

        public virtual Thang Thang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TietHoc> TietHocs { get; set; }
    }
}
