﻿create table NhomQuyen(	
    ID INT IDENTITY(1,1) PRIMARY KEY, -- 0:admin 1:GV 2: HV
	tenNhomQuyen nvarchar(50), 
);
create table TaiKhoan(
    iD INT IDENTITY(1,1) PRIMARY KEY,
	tenDangNhap varchar(50) not null,
	matKhau char(32) not null,	
	trangThai int DEFAULT 1, --0:khóa 1:mở
);

CREATE TABLE TAIKHOAN_NHOMQUYEN(
	IDTAIKHOANNHOMQUYEN INT IDENTITY(1,1) PRIMARY KEY,
	IDTAIHOAN INT NOT NULL,
	IDNHOMQUYEN INT NOT NULL,
	foreign key(IDTAIHOAN) references taikhoan(id),
	foreign key(IDNHOMQUYEN) references NhomQuyen(id),
)

create table ChucNang(	
    iD INT IDENTITY(1,1) PRIMARY KEY,
	tenChucNang nvarchar(50) not null, --Thêm lớp , đăng ký lớp , ....
	tenFile Varchar(128),
	icon Varchar(50),
	iDCha int ,
	foreign key(IDCha) references ChucNang(id)  NOT FOR REPLICATION ,
);

create table ChucNangNhomQuyen(
    idCN INT,
	IDNHOMQUYEN int,
    foreign key(idCN) references  ChucNang(id),
	foreign key(IDNHOMQUYEN) references  NhomQuyen(iD) ,
	primary key (idCN, IDNHOMQUYEN),
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
	gioithieu ntext,
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
	mota ntext,
	hinh text,
	soluong int,
	yeucau nvarchar(50),
	ngayBegin date,
	ngayEnd date,
	soBuoi int,
	trangThai int DEFAULT 1, --0:đóng 1:mở(Df) 2:đang học;
	idGV int,
	
	foreign key(idGV) references  GiangVien(id) ON DELETE CASCADE ,
);

create table DSLopHoc(	
	 idHV int,
	 idLH int,
	 danhgia int,
	 binhluan ntext,
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
	moTa ntext,
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
	noiDung ntext,
	idCha int,
	foreign key(idLH) references  LopHoc(id) ON UPDATE NO ACTION ,
	foreign key(idCha) references  BinhLuan(id) ON UPDATE NO ACTION NOT FOR REPLICATION ,
	foreign key(idTK) references  TaiKhoan(id) ON UPDATE NO ACTION ,
);

create table ThongBao(	
    ID INT IDENTITY(1,1) PRIMARY KEY,
	idTK int,
	noiDung ntext,
	ngay datetime,
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
-- nhập liệu
insert into NhomQuyen
	values ('Admin'),('GiaoVien'),('HocVien');

insert into TaiKhoan --trạng thái 1: mở  0:khóa  Phân quyền 1:admin ; 2Giao vien; 3 hoc vien
	values ('admin','21232f297a57a5a743894a0e4a801fc3',1),
		('loc','202cb962ac59075b964b07152d234b70',1),
		('lochv','202cb962ac59075b964b07152d234b70',1); 

insert into TAIKHOAN_NHOMQUYEN
	values (1,1),(2,2),(3,3);

insert into Giangvien
values (N'lê a','https://drive.google.com/thumbnail?id=14433w0Qp2tnteaXBxQGt5wqInOR6b5O3','123 NVL',N'Nữ','2/22/1999',N'Phó khoa ngoại ngữ đại học Duy Tân','lea@gmail.com','0123456789',2);

insert into LopHoc
values (N'Cơ bản',N'lớp học cho người mất gốc tiếng anh','https://drive.google.com/thumbnail?id=14433w0Qp2tnteaXBxQGt5wqInOR6b5O3',40,'không','5/15/2021','8/15/2021',30,1,1),
(N'Cơ bản',N'lớp học cho người mất gốc tiếng anh lớp học cho người mất gốc tiếng anh lớp học cho người mất gốc tiếng anh lớp học cho người mất gốc tiếng anh lớp học cho người mất gốc tiếng anh lớp học cho người mất gốc tiếng anh','https://drive.google.com/thumbnail?id=14433w0Qp2tnteaXBxQGt5wqInOR6b5O3',40,'không','5/15/2021','8/15/2021',30,1,1);

insert into ChucNang
values (N'Mở Lớp','mo-lop',NULL,0),
(N'Quản lý lớp','ql-lop',NULL,0),
(N'Thời khóa biểu','thoi-khoa-bieu',NULL,0),
(N'Tìm lớp học','tim',NULL,0),
(N'Lớp đã đăng ký','lop-da-dang-ky',NULL,0),
(N'Quản lý giáo viên','ql-giao-vien',NULL,0),
(N'Quản lý học viên','ql-hoc-vien',NULL,0),
(N'Quản lý Báo cáo thống kê','ql-bao-cao',NULL,0),
(N'Thống kê lớp học','thong-ke-lop',NULL,0),
(N'Cập nhật lớp','cap-nhat-lop',NULL,2),
(N'Hủy lớp','huy-lop',NULL,2),
(N'Nghe','nghe',NULL,5),
(N'Nói','noi',NULL,5);

insert into ChucNangNhomQuyen
values 
(1,2),
(2,2),
(3,2),
(3,3),
(4,3),
(5,3),
(6,1),
(7,1),
(8,1),
(9,2),
(10,2),
(11,2),
(12,3),
(13,3);
-- chat giữa học viên và giáo viên



--Procedure

--login
go
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