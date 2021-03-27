create table NhomQuyen(	
    ID INT IDENTITY(1,1) PRIMARY KEY, -- 0:admin 1:GV 2: HV
	tenNhomQuyen nvarchar(50), 
);
create table TaiKhoan(	
    iD INT IDENTITY(1,1) PRIMARY KEY,
	tenDangNhap varchar(50) not null,
	matKhau char(32) not null,	
	trangThai int, --0:khóa 1:mở
	idNQ int not null,
	foreign key(idNQ) references  NhomQuyen(id) ON DELETE CASCADE ,
);

create table ChucNang(	
    ID INT IDENTITY(1,1) PRIMARY KEY,
	tenChucNang nvarchar(50) not null, --Thêm lớp , đăng ký lớp , ....
);
create table ChucNangNhomQuyen(
    idCN INT,
	idNQ int,
    foreign key(idCN) references  ChucNang(id),
	foreign key(idNQ) references  NhomQuyen(id) ,
	primary key (idCN, idNQ),
);
create table HocVien(	
	id INT IDENTITY(1,1) PRIMARY KEY,
    hovaten nvarchar(50) not null, 
	diachi nvarchar(100) ,
	gioitinh nvarchar(3) ,
	ngaysinh date,
	email varchar(50) not null,
	sdt varchar(10) not null,
	idTK int not null,
	foreign key(idTK) references  TaiKhoan(id) ON DELETE CASCADE ,
);

create table Giangvien(	
	ID INT IDENTITY(1,1) PRIMARY KEY,
    hovaten nvarchar(50) , 
	hinh text,
	diachi nvarchar(100) ,
	gioitinh nvarchar(3) ,
	ngaysinh date,
	gioithieu text,
	email varchar(50) not null,
	sdt varchar(10) not null,
	idTK int not null,
	foreign key(idTK) references  TaiKhoan(id) ON DELETE CASCADE ,
);
create table CapDo(	
    ID INT IDENTITY(1,1) PRIMARY KEY,
	tenCapDo nvarchar(50), 
);
create table LopHoc(	
    ID INT IDENTITY(1,1) PRIMARY KEY,
    tenLopHoc nvarchar(50), 
	mota text,
	soluong int,
	yeucau nvarchar(50),
	ngayBegin date,
	ngayEnd date,
	soBuoi int,
	trangThai nvarchar(50), 
	idGV int,
	
	foreign key(idGV) references  GiangVien(id) ON DELETE CASCADE ,
);

create table DSLopHoc(	
	 idHV int,
	 idLH int,
	 danhgia int,
	 binhluan text,
	 foreign key(idHV) references  HocVien(id)ON UPDATE NO ACTION ,
	 foreign key(idLH) references  LopHoc(id) ON UPDATE NO ACTION,
	 primary key (idHV, idLH),
);

create table KyNang(	
	ID INT IDENTITY(1,1) PRIMARY KEY,
	tenKyNang nvarchar(50), --Read Write Speak Listen ,....
);
create table KyNangLopHoc(	
     idKN int,
	 idLH int,
	 idCD INT,
	 foreign key(idKN) references  KyNang(id),
	 foreign key(idLH) references  LopHoc(id),
	 foreign key(idCD) references  CapDo(id) ,
	 primary key (idKN, idLH)
);
create table KyNangGiangVien(	
     idKN int,
	 idGV int,
	 idCD INT,
	 foreign key(idKN) references  KyNang(id) ON DELETE CASCADE ,
	 foreign key(idGV) references  GiangVien(id) ON DELETE CASCADE ,
	 foreign key(idCD) references  CapDo(id) ON DELETE CASCADE ,
	 primary key (idKN, idGV)
);

create table LoaiTaiLieu(	
    ID INT IDENTITY(1,1) PRIMARY KEY,
	tenLoaiTaiLieu nvarchar(50), --video doc mp3
);

create table TaiLieu(	
	ID INT IDENTITY(1,1) PRIMARY KEY,
    link varchar(max) not null,
	moTa text,
	idLoaiTL int,
	idLH int,
	idTK int,
	foreign key(idLoaiTL) references  LoaiTaiLieu(id) ON UPDATE NO ACTION ,
	foreign key(idLH) references  LopHoc(id) ON UPDATE NO ACTION ,
	foreign key(idTK) references  TaiKhoan(id) ON UPDATE NO ACTION ,
);
create table TaiLieuKyNang(	
     idKN int,
	 idLoaiTL int,
	 foreign key(idKN) references  KyNang(id) ON DELETE CASCADE ,
	 foreign key(idLoaiTL) references  LoaiTaiLieu(id) ON DELETE CASCADE ,
	 primary key (idKN, idLoaiTL)
);
create table BinhLuan(	
    ID INT IDENTITY(1,1) PRIMARY KEY,
	idTK int,
	idLH int,
	noiDung text,
	idCha int,
	foreign key(idLH) references  LopHoc(id) ON UPDATE NO ACTION ,
	foreign key(idCha) references  BinhLuan(id) ON UPDATE NO ACTION ,
	foreign key(idTK) references  TaiKhoan(id) ON UPDATE NO ACTION ,
);

create table ThongBao(	
    ID INT IDENTITY(1,1) PRIMARY KEY,
	idTK int,
	noiDung text,
	foreign key(idTK) references  TaiKhoan(id),
);
create table Thu(	--thứ
    ID INT IDENTITY(1,1) PRIMARY KEY,
	tenThu Nvarchar(10)
);
create table GioHoc(	
    ID INT IDENTITY(1,1) PRIMARY KEY,
	gioBegin time,
	gioEnd time,
);
create table ThoiKhoaBieu(	
    ID INT IDENTITY(1,1) PRIMARY KEY,
	idThu int,
	idGioHoc int,
	idLopHoc int,
	foreign key(idThu) references  Thu(id),
	foreign key(idGioHoc) references  GioHoc(id),
	foreign key(idLopHoc) references  lopHoc(id),
);
create table TietHoc(	
    ID INT IDENTITY(1,1) PRIMARY KEY,
	idTKB int,
	idLopHoc int,
	ngay date,
	buoiHoc int, --buổi học thứ mấy
	siso int
	foreign key(idTKB) references  ThoiKhoaBieu(id),
	foreign key(idLopHoc) references  lopHoc(id),
);
go

insert into NhomQuyen
	values ('Admin'),('GiangVien'),('HocVien');

insert into TaiKhoan --trạng thái 1: mở  0:khóa  Phân quyền 1:admin
	values ('admin','21232f297a57a5a743894a0e4a801fc3',1,1); 

-- chat giữa học viên và giáo viên


--Procedure

--login

create proc DangNhap(
	@userName varchar(50),
	@passWord char(32))
as
begin
	declare @dem int
	declare @rec bit
	select @dem = COUNT(*) from TaiKhoan where tenDangNhap = @userName and matKhau = @passWord
	if @dem >0
		set @rec = 1
	else 
		set @rec = 0
	select @rec
end


go
dangnhap 'admin','admin'