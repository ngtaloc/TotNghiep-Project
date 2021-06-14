
create table NhomQuyen(	
    ID INT IDENTITY(1,1) PRIMARY KEY, -- 0:admin 1:GV 2: HV
	tenNhomQuyen nvarchar(50), 
);
create table TaiKhoan(
    iD INT IDENTITY(1,1) PRIMARY KEY,
	hovaten nvarchar(50) , 
	hinh text,
	tenDangNhap varchar(50) not null,
	matKhau char(32) not null,	
	ngayDangKy datetime not null,
	trangThai int DEFAULT 1, --0:khóa 1:mở
	face int DEFAULT 0,--0:đang quét 1:có	-1:chưa có
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
	id INT IDENTITY(1,1) PRIMARY KEY,diachi nvarchar(100) ,
	gioitinh nvarchar(3) ,
	ngaysinh date,
	email varchar(50) not null,
	sdt varchar(10) not null,
	idTK int not null,
	foreign key(idTK) references  TaiKhoan(id) ON DELETE CASCADE ,
);

create table Giangvien(	
	ID INT IDENTITY(1,1) PRIMARY KEY,
    
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
	ngayDangKy datetime not null,
	soBuoi int,
	trangThai int DEFAULT 1, --0:Đang tuyển sinh	1:Ngừng tuyển sinh	2:Đang học	3:Đã kết thúc
	idGV int,
	
	foreign key(idGV) references  GiangVien(id) ON DELETE CASCADE ,
);

create table DSLopHoc(	
	 idHV int,
	 idLH int,
	 ngaydDangKy datetime not null,
	 danhgia int,
	 binhluan ntext,
	 ngayDanhGia datetime,
	 trangthai int,--0: chưa xác nhận vào lớp. 1:đã vào lớp.  -1:bị kick 
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

create table BaiTap(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	tenBT nvarchar(200),
	ngayNop datetime,
	ghiChu ntext,
	ngayDang datetime,
	trangThai int,	--0: đóng 1:mở
	thoiGianLamBai int, --phút
	tuLuan ntext,
);
create table CauHoi(
	ID INT IDENTITY(1,1) PRIMARY KEY,	
	idBT int,
	CauHoi Ntext,
	DapAn Nvarchar(200),
	A Nvarchar(200),
	B Nvarchar(200),
	C Nvarchar(200),
	D Nvarchar(200),
	E Nvarchar(200),
	foreign key(idBT) references  BaiTap(id) ON UPDATE NO ACTION ,
	);

create table TraLoi(
	ID INT IDENTITY(1,1) PRIMARY KEY,	
	idCauHoi int,
	idHV int,
	DapAn Nvarchar(200),	
	thoiGian datetime not null,
	tgLamBai int,
	foreign key(idCauHoi) references CauHoi(id) ON UPDATE NO ACTION ,
	foreign key(idHV) references  HocVien(id) ON UPDATE NO ACTION ,
);
create table fileTraLoi(
	ID INT IDENTITY(1,1) ,
	ten nvarchar(50) NULL,  
	FileSize int NULL,
	link nvarchar(256) not null,
	thoiGian datetime not null,
	trangThai int, --0:dong 1:mo
	idBT int,
	idHV int,
	tgLamBai int,
	foreign key(idBT) references  BaiTap(id) ON UPDATE NO ACTION ,
	foreign key(idHV) references  HocVien(id) ON UPDATE NO ACTION ,
	CONSTRAINT [PK_FilesTL] PRIMARY KEY CLUSTERED   
(  
    [ID] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  ;

create table TaiLieu(	
	ID INT IDENTITY(1,1) ,
	ten nvarchar(50) NULL,  
    FileSize int NULL, 
    link nvarchar(256) not null,
	moTa ntext,
	thoiGian datetime not null,
	trangThai int, --0:dong 1:mo
	idKN int,
	idLH int,
	idTK int,
	idBT int
	foreign key(idKN) references  kyNang(id) ON UPDATE NO ACTION ,
	foreign key(idLH) references  LopHoc(id) ON UPDATE NO ACTION ,
	foreign key(idTK) references  TaiKhoan(id) ON UPDATE NO ACTION ,
	foreign key(idBT) references  BaiTap(id) ON UPDATE NO ACTION ,
	CONSTRAINT [PK_AudioFiles] PRIMARY KEY CLUSTERED   
(  
    [ID] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  ;

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
	thoiGian datetime not null,
	idCha int,
	foreign key(idLH) references  LopHoc(id) ON UPDATE NO ACTION ,
	foreign key(idCha) references  BinhLuan(id) ON UPDATE NO ACTION NOT FOR REPLICATION ,
	foreign key(idTK) references  TaiKhoan(id) ON UPDATE NO ACTION ,
);

create table ThongBao(	
    ID INT IDENTITY(1,1) PRIMARY KEY,
	idTK int,
	noiDung ntext,
	ngay datetime not null,

	link nvarchar(255),
	icon varchar(255), --0:học viên đăng ký lớp học: "fa fa-address-card";  bình luận: "fa fa-comment" ; đánh giá :"fa fa-star" 
	trangThai int, --0:chưa đọc ; 1:đã đọc

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
	thu2 Nvarchar(50),-- time begin - time end
	thu3 Nvarchar(50),--	9-15-11-15
	thu4 Nvarchar(50),
	thu5 Nvarchar(50),
	thu6 Nvarchar(50),
	thu7 Nvarchar(50),
	chunhat Nvarchar(50),
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
	idngayHoc int,
	buoiHoc int, --buổi học thứ mấy
	siso int
	foreign key(idLopHoc) references  lopHoc(id),
	foreign key(idngayHoc) references  ngay(id),
);
create table ViTien(
	iD INT IDENTITY(1,1) PRIMARY KEY,
	SoDu int,
	TongNap int,
	NgayTao date,
	idTK int,
	foreign key(idTK) references  TaiKhoan(id),
);

create table LichSuGD( --lịch sử giao dịch
	iD INT IDENTITY(1,1) PRIMARY KEY,
	ThoiGiangGD datetime not null,
	TenGD Nvarchar(200),
	LoaiGD int, -- 0: Nạp ; 1:Mở Lớp;
	SoTienGD int not null,
	idVT int,
	foreign key(idVT) references  ViTien(id),
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


GO
CREATE procedure [dbo].[spAddNewAudioFile]  
(  
@ten nvarchar(50),  
@FileSize int,  
@link nvarchar(100)  
)  
as  
begin  
insert into tailieu (ten,FileSize,link)   
values (@ten,@FileSize,@link)   
end  

  go

CREATE procedure [dbo].[spGetAllAudioFile]  
as  
begin  
select ID,ten,FileSize,link from tailieu
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
	values (N'Nguyễn Tấn Lộc','','admin','21232f297a57a5a743894a0e4a801fc3','10/20/2020',1,-1),

		(N'lê a','Content\Data\image\user7-128x128.jpg','gv','202cb962ac59075b964b07152d234b70','11/26/2020',1,-1),--https://drive.google.com/thumbnail?id=14433w0Qp2tnteaXBxQGt5wqInOR6b5O3
		(N'Lê Học Viên','','hv','202cb962ac59075b964b07152d234b70','12/21/2020',1,-1); 

insert into TAIKHOAN_NHOMQUYEN
	values (1,1),(2,2),(3,3);


insert into ChucNang
values (N'Mở Lớp','MoLop','fas fa-edit',0),
(N'Quản lý lớp','QLLopHoc','fas fa-school',0),
(N'Thời khóa biểu','ThoiKhoaBieu','fas fa-calendar-alt',0),
(N'Tìm lớp học','Tim','fas fa-search',0),
(N'Quản lý tiết học','Learning','fas fa-clock',0),
(N'Quản lý giáo viên','QLGiaoVien','fas fa-chalkboard-teacher',0),
(N'Quản lý học viên','QLHocVien','fas fa-user-graduate',0),
(N'Quản lý Báo cáo thống kê','QLBaoCao','fas fa-chart-bar',0),
(N'Thống kê lớp học','ThongKe','fas fa-chart-bar',0),
(N'Thông tin cá nhân','Info','fas fa-user-graduate',0),
(N'Quản lý ví tiền','ViTien','fas fa-folder-open',0);


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
(10,3),
(11,2);
insert into Giangvien
values (N'123 NVL',N'Nữ','2/22/1999',N'Phó khoa ngoại ngữ đại học Duy Tân','lea@gmail.com','0123456789',2);

insert into HocVien
values (N'123lê lợi',N'Nam','1998-05-23','hv@gmail.com','0987654321',3);

insert into LopHoc
values (N'Cơ bản',N'lớp học cho người mất gốc tiếng anh','Content/Data/image/photo2.png',40,N'không','4/15/2021','5/15/2021','1/15/2021',30,3,1),
(N'Nâng cao',N'lớp học cho người mất gốc tiếng anh lớp học cho người mất gốc tiếng anh lớp học cho người mất gốc tiếng anh lớp học cho người mất gốc tiếng anh lớp học cho người mất gốc tiếng anh lớp học cho người mất gốc tiếng anh','https://drive.google.com/thumbnail?id=14433w0Qp2tnteaXBxQGt5wqInOR6b5O3',40,N'không','5/15/2021','8/15/2021','2/19/2021',30,2,1);

--insert thời khóa biểu
insert into Ngay(ngay15,ngay20,ngay22,ngay27,ngay29,iDThang,nam,iDLopHoc,thu5,thu3)
--ngày: IDlớpHọc-giờB-PhútB-GiờE-PhútE-BuổiHoc 
values ('1-15-4-2021-9-00-11-00-1','1-20-4-2021-13-00-15-00-2','1-22-4-2021-9-00-11-00-3','1-27-4-2021-13-00-15-00-4','1-29-4-2021-9-00-11-00-5',4,'2021',1,'9-00-11-00','13-00-15-00')
,('1-15-6-2021-9-00-11-00-1','1-20-6-2021-13-00-15-00-2','1-22-6-2021-9-00-11-00-3','1-27-6-2021-13-00-15-00-4','1-29-6-2021-9-00-11-00-5',6,'2021',2,'9-00-11-00','13-00-15-00');
-- chat giữa học viên và giáo viên

insert into DSLopHoc
values (1,1,'4/20/2021',4,N'bình luận abc','5/21/2021',1),
(1,2,'6/20/2021','','','',0);

insert into ThongBao
values (3,N'dk hv mới','2021-04-24 10:00:00.000','#','fa fa-address-card',0),
(3,N'bình luận','2021-03-24 10:00:00.000','#','a fa-comment',0),
(3,N'đánh giá','2020-03-24 12:00:00.000','#','fa fa-star',1)

insert into KyNang
values ('Listening'),
('Speaking'),
('Reading'),
('Writing');

insert into CapDo
values ('Level 1'),
('Level 2'),
('Level 3'),
('Level 4');

Insert into KyNangGiangVien
values (1,1,3),
(2,1,4),
(3,1,3),
(4,1,4);

insert into ViTien
	values (300000,500000,'4/15/2021',2);

insert into LichSuGD
	values ('4/15/2021 10:00',N'500,000 VNĐ vào ví tiền bằng thẻ cào Viettel',0,500000,1),
	('4/15/2021 11:35',N'Có tên Cơ bản và mã lớp LH01 với giá 100.000 VNĐ',1,100000,1),
	('5/1/2021 21:00',N'Có tên Nân cao và mã lớp LH02 với giá 100.000 VNĐ',1,100000,1);


insert into LoaiTaiLieu
values ('DOCX'),('MP3'),('MP4'),('PDF'),('PPTX')

insert into TaiLieuKyNang
values (1,1),(1,2),(1,4),(1,5),--nghe
	(2,1),(2,2),(2,3),(2,4),(2,5),--noi
	(3,1),(3,3),(3,4),(3,5),	--doc
	(4,1),(4,2),(4,3),(4,4),(4,5) ;--viet

	
insert into BinhLuan
values (3,1,N'Bình luận của học viên AAAAAA','4/20/2021 10:50',0),
(3,1,N'Bình luận của học viên zzzz','4/21/2021 11:50',0),
(3,1,N'Bình luận của học viên ','4/21/2021 15:50',0),
(2,1,N'Trả lời của giáo viên aaaaaa','5/15/2021 12:30',1),
(2,1,N'Trả lời của giáo viên bbbbbb','5/15/2021 12:50',1),
(2,1,N'Trả lời Bình luận của học viên zzzz','5/15/2021 10:50',2);



insert into KyNangLopHoc
values
(1,1,1),
(2,1,1),
(3,1,1),
(4,1,1),
(1,2,2),
(3,2,2)



--Thời gian làm bài && thống kê tương tác & trangthai tài liệu