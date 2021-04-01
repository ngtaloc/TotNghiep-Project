namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KyNangLopHoc")]
    public partial class KyNangLopHoc
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idKN { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idLH { get; set; }

        public int? idCD { get; set; }

        public virtual CapDo CapDo { get; set; }

        public virtual KyNang KyNang { get; set; }

        public virtual LopHoc LopHoc { get; set; }
    }
}
