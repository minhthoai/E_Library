create database E_Library
use E_Library
go

create table TaiKhoan_User
(
	MaTaiKhoan int identity(1,1) primary key,
	TenTaiKhoan nvarchar (100),
	MatKhau varchar (20)
)

create table QuanLy_VaiTro
(
	MaVaiTro int identity(1,1) primary key,
	TenVaiTro nvarchar(100),
	MoTa nvarchar (500),
	LanCuoiCapNhat datetime
)

create table ThongTin_NguoiDung
(
	MaNguoiDung int identity(1,1) primary key,
	TenNguoiDung nvarchar(100),
	Email varchar(100),
	MaVaiTro int foreign key references QuanLy_VaiTro(MaVaiTro),
	MaTaiKhoan int foreign key references TaiKhoan_User(MaTaiKhoan),
)

create table GiangVien
(
	MaGiangVien int identity(1,1) primary key,
	TenGiangVien nvarchar(100),
	NgaySinh datetime,
	NoiSinh nvarchar(100),
	Email varchar(50),
	SDT int,
	TrinhDo nvarchar(100),
	MaTaiKhoan int foreign key references TaiKhoan_User(MaTaiKhoan),
)

create table AdminQuanLay
(
	MaAdmin int identity(1,1 ) primary key,
	TenAdmin nvarchar(100),
	TaiKhoanAdmin varchar(100),
	MatKhauAdmin varchar(50),
	MaTaiKhoanUser int foreign key references TaiKhoan_User(MaTaiKhoan), 
	MaVaiTro int foreign key references QuanLy_VaiTro(MaVaiTro),
	MaNguoiDung int foreign key references ThongTin_NguoiDung(MaNguoiDung),
	MaGiangVien int foreign key references GiangVien(MaGiangVien),
	MaBaiGiang int foreign key references BaiGiang(MaBaiGiang),
	MaTep int foreign key references QuanLyTep(MaTep),
	MaTaiNguyen int foreign key references TaiNguyen(MaTaiNguyen),
	MaTaiLieu int foreign key references TaiLieu(MaTaiLieu),
	MaMonHoc int foreign key references MonHoc(MaMonHoc),
	MaDeThi int foreign key references DeThi(MaDeThi),
	MaThongBao int foreign key references ThongBao(MaThongBao),
	MaTroGiup int foreign key references TroGiup(MaTroGiup)
)
--alter table AdminQuanLy 
--add MaTruongHoc int;
--add constraint FK_AdminQuanLy_HeThongThuVien foreign key (MaTruongHoc) references HeThongThuVien(MaTruongHoc);
create table BaiGiang
(
	MaBaiGiang int identity(1,1) primary key,
	TenBaiGiang nvarchar(100),
	Loai nvarchar(100),
	KichThuoc varchar(100),
	MaMonHoc int foreign key references MonHoc(MaMonHoc),
	MaNguoiChinhSua int foreign key references GiangVien(MaGiangVien),
)

create table QuanLyTep
(
	MaTep int identity(1,1) primary key,
	TenTep nvarchar(100),
	TheLoai nvarchar(100),
	NguoiChinhSua int foreign key references GiangVien(MaGiangVien),
	NgayChinhSua datetime,
	KichThuoc varchar(100),
)

create table TaiNguyen
(
	MaTaiNguyen int identity (1,1) primary key,
	TenTaiNgueyn nvarchar(100),
	Loai nvarchar(100),
	KichThuoc nvarchar(100),
	MaMonHoc int,
	NguoiChinhSua int foreign key references GiangVien(MaGiangVien),
)

create table TaiLieu
(
	MaTaiLieu int identity (1,1) primary key,
	TenTaiLieu nvarchar(100),
	Loai nvarchar(100),
	NgayGui datetime,
	TinhTrang nvarchar (100),
	MaGiangVien int foreign key references GiangVien(MaGiangVien),
)

create table MonHoc
(
	MaMonHoc int identity(1,1) primary key,
	TenMonHoc nvarchar(100),
	SoTaiLieuChoDuyett int,
	TinhTrangTaiLieuMonHoc nvarchar(100),
	NgayPheDuyet datetime,
	MaGiangVien int foreign key references GiangVien(MaGiangVien),
)

create table DeThi
(
	MaDeThi int identity(1,1) primary key,
	TenDeThi nvarchar(100),
	TinhTrang nvarchar(100),
	PheDuyet nvarchar(100)
)

create table ChiTiet_DeThi
(
	MaDeThi int identity(1,1)primary key,
	ThoiLuong int,
	HinhThuc nvarchar(100),
	NgayTao datetime,
	PhanCauHoi_DapAn nvarchar(500),
	MaMonHoc int foreign key references MonHoc(MaMonHoc),
	MaGiangVien int foreign key references GiangVien(MaGiangVien),
)

create table TroGiup
(
	MaTroGiup int identity(1,1) primary key,
	TenTroGiup nvarchar(100),
	NoiDung nvarchar(500),	
)

create table ThongBao
(
	MaThongBao int identity(1,1) primary key,
	TenThongBao nvarchar(100),
	NoiDung nvarchar(500),
)

create table HeThongThuVien
(
	MaTruongHoc int identity(1,1) primary key,
	TenTruong nvarchar(100),
	HieuTruong nvarchar(100),
	LoaiTruong nvarchar(50),
	Email varchar(50),
	Website varchar(100),
	DiaChiTruyCap varchar(100),
	SDT int,
	TenHeThongThuVien nvarchar(100),
	NgonNguXacDinh nvarchar(100),
	NienKhoacMacDinh nvarchar(100),
	MaTaiKhoan int foreign key references TaiKhoan_User(MaTaiKhoan),
)

insert into TroGiup (TenTroGiup,NoiDung ) values ('Bai giang','Bai giang chua cap nhat day du');

insert into ThongBao (TenThongBao,NoiDung) values('De thi','Cap nhat dap an bai thi');

insert into ChiTiet_DeThi( ThoiLuong, HinhThuc, NgayTao, PhanCauHoi_DapAn,MaMonHoc,MaGiangVien) values('90', 'Trac nghiem', '2022-03-22','Cau 1 - A',1,1)
insert into DeThi(TenDeThi,TinhTrang,PheDuyet) values('Kiem tra chu de 01','Chu phe duyet','Phe duyet')

insert into TaiKhoan_User (TenTaiKhoan,MatKhau) values('admin','123')
insert into TaiKhoan_User(TenTaiKhoan,MatKhau) values ('teacher1','123')

insert into QuanLy_VaiTro(TenVaiTro,MoTa,LanCuoiCapNhat) values('Quan Tri Vien','Quan ly he thong','2022-03-14')
insert into QuanLy_VaiTro(TenVaiTro,MoTa,LanCuoiCapNhat) values('Nhan Vien','Xem thong tin duoc phan quyen','2022-03-14')
insert into QuanLy_VaiTro(TenVaiTro,MoTa,LanCuoiCapNhat) values('Phong Hanh Chinh','Xem thong tin duoc phan quyen','2022-03-14')

insert into ThongTin_NguoiDung(TenNguoiDung, Email, MaVaiTro, MaTaiKhoan) values('Nguyen Van A', 'vana@gmail.com',1,1)
set identity_insert thongtin_nguoidung off

insert into GiangVien(TenGiangVien, NgaySinh, NoiSinh,Email, SDT, TrinhDo,MaTaiKhoan) values('Le Thi B', '1995-09-15','TP.HCM','thib@gmail.com','123456789','Dai Hoc',2)

insert into MonHoc(TenMonHoc,SoTaiLieuChoDuyett,TinhTrangTaiLieuMonHoc,NgayPheDuyet,MaGiangVien) values('Thuong mai dien tu','15','Chua phe duyet','2022-03-25',1)
--dbcc CHECKIDENT ('HeThongThuVien', RESEED,0)

insert into TaiLieu(TenTaiLieu,Loai,NgayGui,TinhTrang,MaGiangVien) values('Thuong mai dien thu','Bai giang','2022-03-28','Da phe duyet',1)

insert into TaiNguyen(TenTaiNguyen, Loai,KichThuoc,MaMonHoc,NguoiChinhSua) values('GTTMDT01','Word','20mb',1,1)

insert into QuanLyTep( TenTep,TheLoai,NguoiChinhSua,NgayChinhSua,KichThuoc) values('GTTMDT01','Word',1,'2022-03-29','20mb')

insert into BaiGiang(TenBaiGiang,Loai,KichThuoc,MaMonHoc,MaNguoiChinhSua) values('GTTMDT01','Word','20mb',1,1)

insert into HeThongThuVien(TenTruong,HieuTruong,LoaiTruong,Email,Website,DiaChiTruyCap,SDT,TenHeThongThuVien,NgonNguXacDinh,NienKhoacMacDinh,MaTaiKhoan)
values ('Dai Hoc Cong Nghiep','Tran Minh C', 'Dai hoc', 'cn@gmail.com','daihoccongnghiep','www.daihoccongnghiep.com','123345678','Thuong vien lau 1','Tieng viet','2021-2022',1)

insert into AdminQuanLy(TenAdmin, TaiKhoanAdmin,MatKhauAdmin, MaTaiKhoanUser, MaVaiTro,MaNguoiDung,MaGiangVien,MaBaiGiang,MaTep,MaTaiNguyen,MaTaiLieu,MaMonHoc,MaDeThi,MaThongBao,MaTroGiup,MaTruongHoc)
values ('Le Van D','admin','123',1,1,1,1,1,1,1,1,1,1,1,1,1)