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

        public virtual DbSet<BaiTap> BaiTaps { get; set; }
        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<CapDo> CapDoes { get; set; }
        public virtual DbSet<CauHoi> CauHois { get; set; }
        public virtual DbSet<ChucNang> ChucNangs { get; set; }
        public virtual DbSet<DSLopHoc> DSLopHocs { get; set; }
        public virtual DbSet<fileTraLoi> fileTraLois { get; set; }
        public virtual DbSet<Giangvien> Giangviens { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<KyNang> KyNangs { get; set; }
        public virtual DbSet<KyNangGiangVien> KyNangGiangViens { get; set; }
        public virtual DbSet<KyNangLopHoc> KyNangLopHocs { get; set; }
        public virtual DbSet<LichSuGD> LichSuGDs { get; set; }
        public virtual DbSet<LoaiTaiLieu> LoaiTaiLieux { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<Nam> Nams { get; set; }
        public virtual DbSet<Ngay> Ngays { get; set; }
        public virtual DbSet<NhomQuyen> NhomQuyens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TAIKHOAN_NHOMQUYEN> TAIKHOAN_NHOMQUYEN { get; set; }
        public virtual DbSet<TaiLieu> TaiLieux { get; set; }
        public virtual DbSet<Thang> Thangs { get; set; }
        public virtual DbSet<ThongBao> ThongBaos { get; set; }
        public virtual DbSet<TietHoc> TietHocs { get; set; }
        public virtual DbSet<TraLoi> TraLois { get; set; }
        public virtual DbSet<ViTien> ViTiens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiTap>()
                .HasMany(e => e.CauHois)
                .WithOptional(e => e.BaiTap)
                .HasForeignKey(e => e.idBT);

            modelBuilder.Entity<BaiTap>()
                .HasMany(e => e.fileTraLois)
                .WithOptional(e => e.BaiTap)
                .HasForeignKey(e => e.idBT);

            modelBuilder.Entity<BaiTap>()
                .HasMany(e => e.TaiLieux)
                .WithOptional(e => e.BaiTap)
                .HasForeignKey(e => e.idBT);

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

            modelBuilder.Entity<CauHoi>()
                .HasMany(e => e.TraLois)
                .WithOptional(e => e.CauHoi)
                .HasForeignKey(e => e.idCauHoi);

            modelBuilder.Entity<ChucNang>()
                .Property(e => e.tenFile)
                .IsUnicode(false);

            modelBuilder.Entity<ChucNang>()
                .Property(e => e.icon)
                .IsUnicode(false);

            modelBuilder.Entity<ChucNang>()
                .HasMany(e => e.ChucNang1)
                .WithOptional(e => e.ChucNang2)
                .HasForeignKey(e => e.iDCha);

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

            modelBuilder.Entity<HocVien>()
                .HasMany(e => e.fileTraLois)
                .WithOptional(e => e.HocVien)
                .HasForeignKey(e => e.idHV);

            modelBuilder.Entity<HocVien>()
                .HasMany(e => e.TraLois)
                .WithOptional(e => e.HocVien)
                .HasForeignKey(e => e.idHV);

            modelBuilder.Entity<KyNang>()
                .HasMany(e => e.KyNangGiangViens)
                .WithRequired(e => e.KyNang)
                .HasForeignKey(e => e.idKN);

            modelBuilder.Entity<KyNang>()
                .HasMany(e => e.KyNangLopHocs)
                .WithRequired(e => e.KyNang)
                .HasForeignKey(e => e.idKN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KyNang>()
                .HasMany(e => e.TaiLieux)
                .WithOptional(e => e.KyNang)
                .HasForeignKey(e => e.idKN);

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
                .HasMany(e => e.Ngays)
                .WithOptional(e => e.LopHoc)
                .HasForeignKey(e => e.iDLopHoc);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.TaiLieux)
                .WithOptional(e => e.LopHoc)
                .HasForeignKey(e => e.idLH);

            modelBuilder.Entity<LopHoc>()
                .HasMany(e => e.TietHocs)
                .WithOptional(e => e.LopHoc)
                .HasForeignKey(e => e.idLopHoc);

            modelBuilder.Entity<Nam>()
                .Property(e => e.nam1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Nam>()
                .HasMany(e => e.Ngays)
                .WithOptional(e => e.Nam1)
                .HasForeignKey(e => e.nam);

            modelBuilder.Entity<Ngay>()
                .Property(e => e.nam)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Ngay>()
                .HasMany(e => e.TietHocs)
                .WithOptional(e => e.Ngay)
                .HasForeignKey(e => e.idngayHoc);

            modelBuilder.Entity<NhomQuyen>()
                .HasMany(e => e.TAIKHOAN_NHOMQUYEN)
                .WithRequired(e => e.NhomQuyen)
                .HasForeignKey(e => e.IDNHOMQUYEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhomQuyen>()
                .HasMany(e => e.ChucNangs)
                .WithMany(e => e.NhomQuyens)
                .Map(m => m.ToTable("ChucNangNhomQuyen").MapLeftKey("IDNHOMQUYEN").MapRightKey("idCN"));

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.hinh)
                .IsUnicode(false);

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
                .HasMany(e => e.TAIKHOAN_NHOMQUYEN)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.IDTAIHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.TaiLieux)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.idTK);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.ThongBaos)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.idTK);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.ViTiens)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.idTK);

            modelBuilder.Entity<Thang>()
                .HasMany(e => e.Ngays)
                .WithOptional(e => e.Thang)
                .HasForeignKey(e => e.iDThang);

            modelBuilder.Entity<ThongBao>()
                .Property(e => e.icon)
                .IsUnicode(false);

            modelBuilder.Entity<ViTien>()
                .HasMany(e => e.LichSuGDs)
                .WithOptional(e => e.ViTien)
                .HasForeignKey(e => e.idVT);
        }
    }
}
