using System.ComponentModel.DataAnnotations;
namespace E_Library.Model
{
    public class ThongTin_NguoiDung
    {
        [Key]
        public int MaNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }= string.Empty;
        public string Email { get; set; }= string.Empty;
        public string VaiTro { get; set; }= string.Empty;
    }
}
