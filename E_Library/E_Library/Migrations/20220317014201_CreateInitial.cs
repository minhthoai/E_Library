using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Library.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adMin",
                columns: table => new
                {
                    maAdmin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    taiKhoanAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    matkhauAdmin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adMin", x => x.maAdmin);
                });

            migrationBuilder.CreateTable(
                name: "baiGiang",
                columns: table => new
                {
                    MaBaiGiang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBaiGiang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KichThuoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baiGiang", x => x.MaBaiGiang);
                });

            migrationBuilder.CreateTable(
                name: "chiTiet_deThi",
                columns: table => new
                {
                    MaDeThi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThoiLuong = table.Column<int>(type: "int", nullable: false),
                    HinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CauHoiDapAn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chiTiet_deThi", x => x.MaDeThi);
                });

            migrationBuilder.CreateTable(
                name: "deThi",
                columns: table => new
                {
                    MaDeThi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDeThi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PheDuyet = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deThi", x => x.MaDeThi);
                });

            migrationBuilder.CreateTable(
                name: "heThong",
                columns: table => new
                {
                    MaTruong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTruong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HieuTruong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiTruong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiTruyCap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<int>(type: "int", nullable: false),
                    TenHeThongThuVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgonNguXacDinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NienKhoaMacDinh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_heThong", x => x.MaTruong);
                });

            migrationBuilder.CreateTable(
                name: "monHoc",
                columns: table => new
                {
                    MaMonHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoTaiLieuChoDuyet = table.Column<int>(type: "int", nullable: false),
                    TinhTrangTaiLieuMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayPheDuyet = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monHoc", x => x.MaMonHoc);
                });

            migrationBuilder.CreateTable(
                name: "quanLy_VaiTros",
                columns: table => new
                {
                    MaVaiTro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanCuoiCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quanLy_VaiTros", x => x.MaVaiTro);
                });

            migrationBuilder.CreateTable(
                name: "quanLyTeps",
                columns: table => new
                {
                    MaTep = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayChinhSua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KichThuoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quanLyTeps", x => x.MaTep);
                });

            migrationBuilder.CreateTable(
                name: "taiKhoan",
                columns: table => new
                {
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taiKhoan", x => x.MaTaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "taiLieus",
                columns: table => new
                {
                    MaTaiLieu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTaiLieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taiLieus", x => x.MaTaiLieu);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    MaTeacher = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTeacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoiSinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<int>(type: "int", nullable: false),
                    TrinhDo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.MaTeacher);
                });

            migrationBuilder.CreateTable(
                name: "thongBaos",
                columns: table => new
                {
                    MaThongBao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThongBao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thongBaos", x => x.MaThongBao);
                });

            migrationBuilder.CreateTable(
                name: "thongTin_NguoiDungs",
                columns: table => new
                {
                    MaNguoiDung = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thongTin_NguoiDungs", x => x.MaNguoiDung);
                });

            migrationBuilder.CreateTable(
                name: "troGiups",
                columns: table => new
                {
                    MaTroGiup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTroGiup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_troGiups", x => x.MaTroGiup);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adMin");

            migrationBuilder.DropTable(
                name: "baiGiang");

            migrationBuilder.DropTable(
                name: "chiTiet_deThi");

            migrationBuilder.DropTable(
                name: "deThi");

            migrationBuilder.DropTable(
                name: "heThong");

            migrationBuilder.DropTable(
                name: "monHoc");

            migrationBuilder.DropTable(
                name: "quanLy_VaiTros");

            migrationBuilder.DropTable(
                name: "quanLyTeps");

            migrationBuilder.DropTable(
                name: "taiKhoan");

            migrationBuilder.DropTable(
                name: "taiLieus");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "thongBaos");

            migrationBuilder.DropTable(
                name: "thongTin_NguoiDungs");

            migrationBuilder.DropTable(
                name: "troGiups");
        }
    }
}
