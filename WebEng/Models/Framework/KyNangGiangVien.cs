namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KyNangGiangVien")]
    public partial class KyNangGiangVien
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idKN { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idGV { get; set; }

        public int? idCD { get; set; }

        public virtual CapDo CapDo { get; set; }

        public virtual Giangvien Giangvien { get; set; }

        public virtual KyNang KyNang { get; set; }
    }
}
