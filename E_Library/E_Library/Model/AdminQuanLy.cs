using System.ComponentModel.DataAnnotations;
namespace E_Library.Model
{
    public class AdminQuanLy
    {
        [Key]
        public int maAdmin { get; set; }
        public string tenAdmin { get; set; } = string.Empty;
        public string taiKhoanAdmin { get; set; } = string .Empty;
        public string matkhauAdmin { get; set; } = string .Empty;

    }
}
