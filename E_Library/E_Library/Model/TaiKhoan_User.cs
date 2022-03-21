using System.ComponentModel.DataAnnotations;
namespace E_Library.Model
{
    public class TaiKhoan_User
    {
        [Key]
        public int MaTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }=   string.Empty;
        public string MatKhau { get; set; } = string.Empty;
    }
}
