using E_Library.Model;
using Microsoft.EntityFrameworkCore;
namespace E_Library.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<AdminQuanLy> adMinQuanLy { get; set; }
        public DbSet<BaiGiang> baiGiang { get; set; }
        public DbSet<ChiTiet_DeThi> chiTiet_deThi { get; set; }
        public DbSet<DeThi> deThi { get; set; }
        public DbSet<HeThongThuVien> heThongThuVien { get; set; }
        public DbSet<MonHoc> monHoc { get; set; }
        public DbSet<QuanLy_VaiTro> quanLy_VaiTro { get; set; }
        public DbSet<QuanLyTep> quanLyTep { get; set; }
        public DbSet<TaiKhoan_User> taiKhoan_User { get; set; }
        public DbSet<TaiLieu> taiLieu { get; set; }
        public DbSet<TaiNguyen> taiNguyen { get; set; }
        public DbSet<Teacher> teacher { get; set; }
        public DbSet<ThongBao> thongBaos { get; set; }
        public DbSet<ThongTin_NguoiDung> thongTin_NguoiDung { get; set; }
        public DbSet<TroGiup> troGiup { get; set; }
    }
}
