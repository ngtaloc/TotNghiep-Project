create table NhomQuyen(	
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
<<<<<<< HEAD
=======
	link varchar(255),
	icon varchar(255), --0:học viên đăng ký lớp học: "fa fa-address-card";  bình luận: "fa fa-comment" ; đánh giá :"fa fa-star" 
	trangThai int, --0:chưa đọc ; 1:đã đọc
>>>>>>> refs/remotes/origin/main
	foreign key(idTK) references  TaiKhoan(id),
);
-------Thời khóa biểu
create table Nam(--năm
	nam char(4)  PRIMARY KEY,
);
create table Thang(--tháng
	iD INT IDENTITY(1,1) PRIMARY KEY,
	tenThang Nvarchar(10),
	
);
create table Ngay(	--ngày
    iD INT IDENTITY(1,1) PRIMARY KEY,
	ngay1 Nvarchar(50), -- IDlớpHọc-ngay-thang-nam-giờB-PhútB-GiờE-PhútE 
	ngay2 Nvarchar(50), --vd: LH12-2-5-2021-7-00-9-00
	ngay3 Nvarchar(50),
	ngay4 Nvarchar(50),
	ngay5 Nvarchar(50),
	ngay6 Nvarchar(50),
	ngay7 Nvarchar(50),
	ngay8 Nvarchar(50),
	ngay9 Nvarchar(50),
	ngay10 Nvarchar(50),
	ngay11 Nvarchar(50),
	ngay12 Nvarchar(50),
	ngay13 Nvarchar(50),
	ngay14 Nvarchar(50),
	ngay15 Nvarchar(50),
	ngay16 Nvarchar(50),
	ngay17 Nvarchar(50),
	ngay18 Nvarchar(50),
	ngay19 Nvarchar(50),
	ngay20 Nvarchar(50),
	ngay21 Nvarchar(50),
	ngay22 Nvarchar(50),
	ngay23 Nvarchar(50),
	ngay24 Nvarchar(50),
	ngay25 Nvarchar(50),
	ngay26 Nvarchar(50),
	ngay27 Nvarchar(50),
	ngay28 Nvarchar(50),
	ngay29 Nvarchar(50),
	ngay30 Nvarchar(50),
	ngay31 Nvarchar(50),
	iDThang int,
	nam char(4),
	iDLopHoc int,
	foreign key(iDThang) references  Thang(iD),
	foreign key(nam) references  Nam(nam),
	foreign key(iDLopHoc) references LopHoc(id),
);

create table TietHoc(	
    ID INT IDENTITY(1,1) PRIMARY KEY,
	idLopHoc int,
	ngayHoc int,
	buoiHoc int, --buổi học thứ mấy
	siso int
	foreign key(idLopHoc) references  lopHoc(id),
	foreign key(ngayHoc) references  ngay(id),
);
go

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

  
go
-- nhập liệu
insert into Nam
	values ('2017'),('2018'),('2019'),('2020'),('2021'),('2022'),('2023'),('2024');
insert into Thang
	values (N'Tháng 1'),(N'Tháng 2'),(N'Tháng 3'),(N'Tháng 4'),(N'Tháng 5'),(N'Tháng 6'),(N'Tháng 7'),(N'Tháng 8'),(N'Tháng 9'),(N'Tháng 10'),(N'Tháng 11'),(N'Tháng 12');
	

insert into NhomQuyen
	values ('Admin'),('GiaoVien'),('HocVien');

insert into TaiKhoan --trạng thái 1: mở  0:khóa  Phân quyền 1:admin ; 2Giao vien; 3 hoc vien
	values ('admin','21232f297a57a5a743894a0e4a801fc3',1),

		('gv','202cb962ac59075b964b07152d234b70',1),
		('hv','202cb962ac59075b964b07152d234b70',1); 

insert into TAIKHOAN_NHOMQUYEN
	values (1,1),(2,2),(3,3);


insert into ChucNang
values (N'Mở Lớp','MoLop',NULL,0),
(N'Quản lý lớp','QLLop',NULL,0),
(N'Thời khóa biểu','ThoiKhoaBieu',NULL,0),
(N'Tìm lớp học','Home',NULL,0),
(N'Lớp đã đăng ký','Learning',NULL,0),
(N'Quản lý giáo viên','QLGiaoVien',NULL,0),
(N'Quản lý học viên','QLHocVien',NULL,0),
(N'Quản lý Báo cáo thống kê','QLBaoCao',NULL,0),
(N'Thống kê lớp học','ThongKeLop',NULL,0),
(N'Cập nhật lớp','CapNhatLop',NULL,2),
(N'Hủy lớp','HuyLop',NULL,2);


insert into ChucNangNhomQuyen
values (1,2),
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
(11,2);
insert into Giangvien
values (N'lê a','https://drive.google.com/thumbnail?id=14433w0Qp2tnteaXBxQGt5wqInOR6b5O3','123 NVL',N'Nữ','2/22/1999',N'Phó khoa ngoại ngữ đại học Duy Tân','lea@gmail.com','0123456789',2);

insert into HocVien
values (N'Lê Học Viên',N'123le loi',N'Nữ','1998-05-23','hv@gmail.com','0987654321',3);

insert into LopHoc
values (N'Cơ bản',N'lớp học cho người mất gốc tiếng anh','https://drive.google.com/thumbnail?id=14433w0Qp2tnteaXBxQGt5wqInOR6b5O3',40,'không','4/15/2021','8/15/2021',30,1,1),
(N'Nân cao',N'lớp học cho người mất gốc tiếng anh lớp học cho người mất gốc tiếng anh lớp học cho người mất gốc tiếng anh lớp học cho người mất gốc tiếng anh lớp học cho người mất gốc tiếng anh lớp học cho người mất gốc tiếng anh','https://drive.google.com/thumbnail?id=14433w0Qp2tnteaXBxQGt5wqInOR6b5O3',40,'không','5/15/2021','8/15/2021',30,1,1);

--insert thời khóa biểu
insert into Ngay(ngay15,ngay20,ngay22,ngay27,ngay29,iDThang,nam,iDLopHoc)
--ngày: IDlớpHọc-giờB-PhútB-GiờE-PhútE 
values ('1-15-4-2021-9-00-11-00','1-20-4-2021-13-00-15-00','1-22-4-2021-9-00-11-00','1-27-4-2021-13-00-15-00','1-29-4-2021-9-00-11-00',4,'2021',1);
-- chat giữa học viên và giáo viên


insert into ThongBao
values (3,N'dk hv mới','2021-04-24 10:00:00.000','#','fa fa-address-card',0),
(3,N'bình luận','2021-03-24 10:00:00.000','#','a fa-comment',0),
(3,N'đánh giá','2020-03-24 12:00:00.000','#','fa fa-star',1)

insert into KyNang
values ('Listening'),
('Speaking'),
('Reading'),
('Writing');