namespace Models.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebEngDbContext : DbContext
    {
        public WebEngDbContext()
            : base("name=WebEngDbContext")
        {
        }

        public virtual DbSet<BinhLuan> BinhLuan { get; set; }
        public virtual DbSet<CapDo> CapDo { get; set; }
        public virtual DbSet<ChucNang> ChucNang { get; set; }
        public virtual DbSet<DSLopHoc> DSLopHoc { get; set; }
        public virtual DbSet<Giangvien> Giangvien { get; set; }
        public virtual DbSet<GioHoc> GioHoc { get; set; }
        public virtual DbSet<HocVien> HocVien { get; set; }
        public virtual DbSet<KyNang> KyNang { get; set; }
        public virtual DbSet<KyNangGiangVien> KyNangGiangVien { get; set; }
        public virtual DbSet<KyNangLopHoc> KyNangLopHoc { get; set; }
        public virtual DbSet<LoaiTaiLieu> LoaiTaiLieu { get; set; }
        public virtual DbSet<LopHoc> LopHoc { get; set; }
        public virtual DbSet<NhomQuyen> NhomQuyen { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<TaiLieu> TaiLieu { get; set; }
        public virtual DbSet<TietHoc> TietHoc { get; set; }
        public virtual DbSet<ThoiKhoaBieu> ThoiKhoaBieu { get; set; }
        public virtual DbSet<ThongBao> ThongBao { get; set; }
        public virtual DbSet<Thu> Thu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.noiDung)
                .IsUnicode(false);

            modelBuilder.Entity<BinhLuan>()
                .HasMany(e => e.BinhLuan1)
                .WithOptional(e => e.BinhLuan2)
                .HasForeignKey(e => e.idCha);

            modelBuilder.Entity<CapDo>()
                .HasMany(e => e.KyNangGiangVien)
                .WithOptional(e => e.CapDo)
                .HasForeignKey(e => e.idCD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CapDo>()
                .HasMany(e => e.KyNangLopHoc)
                .WithOptional(e => e.CapDo)
                .HasForeignKey(e => e.idCD);

            modelBuilder.Entity<ChucNang>()
                .HasMany(e => e.NhomQuyen)
                .WithMany(e => e.ChucNang)
                .Map(m => m.ToTable("ChucNangNhomQuyen").MapLeftKey("idCN").MapRightKey("idNQ"));

            modelBuilder.Entity<DSLopHoc>()
                .Property(e => e.binhluan)
                .IsUnicode(false);

            modelBuilder.Entity<Giangvien>()
                .Property(e => e.hinh)
                .IsUnicode(false);

            modelBuilder.Entity<Giangvien>()
                .Property(e => e.gioithieu)
                .IsUnicode(false);

            modelBuilder.Entity<Giangvien>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Giangvien>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<Giangvien>()
                .HasMany(e => e.KyNangGiangVien)
                .WithRequired(e => e.Giangvien)
                .HasForeignKey(e => e.idGV);

            modelBuilder.Entity<Giangvien>()
                .HasMany(e => e.LopHoc)
                .WithOptional(e => e.Giangvien)
                .HasForeignKey(e => e.idGV)
                .WillCascadeOnDelete();

            modelBuilder.Entity<GioHoc>()
                .HasMany(e => e.ThoiKhoaBieu)
                .WithOptional(e => e.GioHoc)
                .HasForeignKey(e => e.idGioHoc);

            modelBuilder.Entity<HocVien>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<HocVien>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<HocVien>()
                .HasMany(e => e.DSLopHoc)
                .WithRequired(e => e.HocVien)
                .HasForeignKey(e => e.idHV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KyNang>()
                .HasMany(e => e.KyNangGiangVien)
                .WithRequired(e => e.KyNang)
                .HasForeignKey(e => e.idKN);

            modelBuilder.Entity<KyNang>()
                .HasMany(e => e.KyNangLopHoc)
                .WithRequired(e => e.KyNang)
                .HasForeignKey(e => e.idKN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiTaiLieu>()
                .HasMany(e => e.TaiLieu)
                .WithOptional(e => e.LoaiTaiLieu)
                .HasForeignKey(e => e.idLoaiTL);

            modelBuilder.Entity<LoaiTaiLieu>()
                .HasMany(e => e.KyNang)
                .WithMany(e => e.LoaiTaiLieu)
                .Map(m => m.ToTable("TaiLieuKyNang").MapLeftKey("idLoaiTL").MapRightKey("idKN"));

            modelBuilder.Entity<LopHoc>()
                .Property(e => e.mota)
                .IsUnicode(false);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.BinhLuan)
                .WithOptional(e => e.LopHoc)
                .HasForeignKey(e => e.idLH);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.DSLopHoc)
                .WithRequired(e => e.LopHoc)
                .HasForeignKey(e => e.idLH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.KyNangLopHoc)
                .WithRequired(e => e.LopHoc)
                .HasForeignKey(e => e.idLH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.TaiLieu)
                .WithOptional(e => e.LopHoc)
                .HasForeignKey(e => e.idLH);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.TietHoc)
                .WithOptional(e => e.LopHoc)
                .HasForeignKey(e => e.idLopHoc);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.ThoiKhoaBieu)
                .WithOptional(e => e.LopHoc)
                .HasForeignKey(e => e.idLopHoc);

            modelBuilder.Entity<NhomQuyen>()
                .HasMany(e => e.TaiKhoan)
                .WithRequired(e => e.NhomQuyen)
                .HasForeignKey(e => e.idNQ);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.tenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.matKhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.BinhLuan)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.idTK);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.Giangvien)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.idTK);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.HocVien)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.idTK);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.TaiLieu)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.idTK);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.ThongBao)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.idTK);

            modelBuilder.Entity<TaiLieu>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<TaiLieu>()
                .Property(e => e.moTa)
                .IsUnicode(false);

            modelBuilder.Entity<ThoiKhoaBieu>()
                .HasMany(e => e.TietHoc)
                .WithOptional(e => e.ThoiKhoaBieu)
                .HasForeignKey(e => e.idTKB);

            modelBuilder.Entity<ThongBao>()
                .Property(e => e.noiDung)
                .IsUnicode(false);

            modelBuilder.Entity<Thu>()
                .HasMany(e => e.ThoiKhoaBieu)
                .WithOptional(e => e.Thu)
                .HasForeignKey(e => e.idThu);
        }
    }
}
