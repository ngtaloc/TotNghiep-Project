namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TAIKHOAN_NHOMQUYEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN_NHOMQUYEN()
        {
            ChucNangs = new HashSet<ChucNang>();
        }

        [Key]
        public int IDTAIKHOANNHOMQUYEN { get; set; }

        public int IDTAIHOAN { get; set; }

        public int IDNHOMQUYEN { get; set; }

        public virtual NhomQuyen NhomQuyen { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChucNang> ChucNangs { get; set; }
    }
}
