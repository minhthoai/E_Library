using System.ComponentModel.DataAnnotations;
namespace E_Library.Model
{
    public class HeThongThuVien
    {
        [Key]
        public int MaTruongHoc { get; set; }
        public string TenTruong { get; set; }= string.Empty;
        public string HieuTruong { get; set; }= string.Empty;   
        public string LoaiTruong { get; set; }= string.Empty;
        public string Email { get; set; }= string.Empty;
        public string Website { get; set; }= string.Empty;
        public string DiaChiTruyCap { get; set; }= string.Empty;
        public int SDT { get; set; }
        public string TenHeThongThuVien { get; set; }= string.Empty;
        public string NgonNguXacDinh { get; set; }= string.Empty;
        public string NienKhoacMacDinh { get; set; }= string.Empty;
        //public int MaTaiKhoan { get; set; }
    }
}
