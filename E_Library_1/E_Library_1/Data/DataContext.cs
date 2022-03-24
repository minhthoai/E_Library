using E_Library_1.Model;
using Microsoft.EntityFrameworkCore;
namespace E_Library_1.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<BaiGiang> BaiGiang { get; set; }
        public DbSet<DeThi> DeThi { get; set; }
        public DbSet<LuuFile> LuuFile { get; set; }
        public DbSet<MonHoc> MonHoc { get; set; }
        public DbSet<NguoiDung> NguoiDung { get; set; }
        public DbSet<TaiLieu> TaiLieu { get; set; }
        public DbSet<TaiNguyen> TaiNguyen { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Tep> Tep { get; set; }
        public DbSet<ThongBao> ThongBao { get; set; }
        public DbSet<TroGiup> TroGiup { get; set; }
        public DbSet<VaiTro> VaiTro { get; set; }
    }
}
