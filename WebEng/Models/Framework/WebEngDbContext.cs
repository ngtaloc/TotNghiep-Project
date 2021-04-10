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

        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<CapDo> CapDoes { get; set; }
        public virtual DbSet<ChucNang> ChucNangs { get; set; }
        public virtual DbSet<DSLopHoc> DSLopHocs { get; set; }
        public virtual DbSet<Giangvien> Giangviens { get; set; }
        public virtual DbSet<GioHoc> GioHocs { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<KyNang> KyNangs { get; set; }
        public virtual DbSet<KyNangGiangVien> KyNangGiangViens { get; set; }
        public virtual DbSet<KyNangLopHoc> KyNangLopHocs { get; set; }
        public virtual DbSet<LoaiTaiLieu> LoaiTaiLieux { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<NhomQuyen> NhomQuyens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TaiLieu> TaiLieux { get; set; }
        public virtual DbSet<ThoiKhoaBieu> ThoiKhoaBieux { get; set; }
        public virtual DbSet<ThongBao> ThongBaos { get; set; }
        public virtual DbSet<Thu> Thus { get; set; }
        public virtual DbSet<TietHoc> TietHocs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinhLuan>()
                .HasMany(e => e.BinhLuan1)
                .WithOptional(e => e.BinhLuan2)
                .HasForeignKey(e => e.idCha);

            modelBuilder.Entity<CapDo>()
                .HasMany(e => e.KyNangGiangViens)
                .WithOptional(e => e.CapDo)
                .HasForeignKey(e => e.idCD)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CapDo>()
                .HasMany(e => e.KyNangLopHocs)
                .WithOptional(e => e.CapDo)
                .HasForeignKey(e => e.idCD);

            modelBuilder.Entity<ChucNang>()
                .HasMany(e => e.NhomQuyens)
                .WithMany(e => e.ChucNangs)
                .Map(m => m.ToTable("ChucNangNhomQuyen").MapLeftKey("idCN").MapRightKey("idNQ"));

            modelBuilder.Entity<Giangvien>()
                .Property(e => e.hinh)
                .IsUnicode(false);

            modelBuilder.Entity<Giangvien>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Giangvien>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<Giangvien>()
                .HasMany(e => e.KyNangGiangViens)
                .WithRequired(e => e.Giangvien)
                .HasForeignKey(e => e.idGV);

            modelBuilder.Entity<Giangvien>()
                .HasMany(e => e.LopHocs)
                .WithOptional(e => e.Giangvien)
                .HasForeignKey(e => e.idGV)
                .WillCascadeOnDelete();

            modelBuilder.Entity<GioHoc>()
                .HasMany(e => e.ThoiKhoaBieux)
                .WithOptional(e => e.GioHoc)
                .HasForeignKey(e => e.idGioHoc);

            modelBuilder.Entity<HocVien>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<HocVien>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<HocVien>()
                .HasMany(e => e.DSLopHocs)
                .WithRequired(e => e.HocVien)
                .HasForeignKey(e => e.idHV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KyNang>()
                .HasMany(e => e.KyNangGiangViens)
                .WithRequired(e => e.KyNang)
                .HasForeignKey(e => e.idKN);

            modelBuilder.Entity<KyNang>()
                .HasMany(e => e.KyNangLopHocs)
                .WithRequired(e => e.KyNang)
                .HasForeignKey(e => e.idKN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiTaiLieu>()
                .HasMany(e => e.TaiLieux)
                .WithOptional(e => e.LoaiTaiLieu)
                .HasForeignKey(e => e.idLoaiTL);

            modelBuilder.Entity<LoaiTaiLieu>()
                .HasMany(e => e.KyNangs)
                .WithMany(e => e.LoaiTaiLieux)
                .Map(m => m.ToTable("TaiLieuKyNang").MapLeftKey("idLoaiTL").MapRightKey("idKN"));

            modelBuilder.Entity<LopHoc>()
                .Property(e => e.hinh)
                .IsUnicode(false);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.BinhLuans)
                .WithOptional(e => e.LopHoc)
                .HasForeignKey(e => e.idLH);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.DSLopHocs)
                .WithRequired(e => e.LopHoc)
                .HasForeignKey(e => e.idLH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.KyNangLopHocs)
                .WithRequired(e => e.LopHoc)
                .HasForeignKey(e => e.idLH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.TaiLieux)
                .WithOptional(e => e.LopHoc)
                .HasForeignKey(e => e.idLH);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.ThoiKhoaBieux)
                .WithOptional(e => e.LopHoc)
                .HasForeignKey(e => e.idLopHoc);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.TietHocs)
                .WithOptional(e => e.LopHoc)
                .HasForeignKey(e => e.idLopHoc);

            modelBuilder.Entity<NhomQuyen>()
                .HasMany(e => e.TaiKhoans)
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
                .HasMany(e => e.BinhLuans)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.idTK);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.Giangviens)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.idTK);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.HocViens)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.idTK);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.TaiLieux)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.idTK);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.ThongBaos)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.idTK);

            modelBuilder.Entity<TaiLieu>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<ThoiKhoaBieu>()
                .HasMany(e => e.TietHocs)
                .WithOptional(e => e.ThoiKhoaBieu)
                .HasForeignKey(e => e.idTKB);

            modelBuilder.Entity<Thu>()
                .HasMany(e => e.ThoiKhoaBieux)
                .WithOptional(e => e.Thu)
                .HasForeignKey(e => e.idThu);
        }
    }
}
