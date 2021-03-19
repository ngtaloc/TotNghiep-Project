create table PhanQuyen(	
    id INT IDENTITY(1,1) PRIMARY KEY,
    tenPhanQuyen nvarchar(50) not null,  --admin hocvien giangvien
);

create table TaiKhoan(	
    id INT IDENTITY(1,1) PRIMARY KEY,
	tenDangNhap varchar(50) not null,
	matKhau char(32) not null,	
	trangThai int,
	idPQ int not null,
	foreign key(idPQ) references  PhanQuyen(id) ON DELETE CASCADE ,
);

create table HocVien(	
	id INT IDENTITY(1,1) PRIMARY KEY,
    hovaten nvarchar(50) , 
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
	idGV int,
	idCD int,
	foreign key(idGV) references  GiangVien(id) ON DELETE CASCADE ,
	foreign key(idCD) references  CapDo(id) ON DELETE CASCADE , 
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


-- chat giữa học viên và giáo viên