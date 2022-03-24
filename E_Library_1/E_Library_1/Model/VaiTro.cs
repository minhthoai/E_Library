using System.ComponentModel.DataAnnotations;
namespace E_Library_1.Model
{
    public class VaiTro
    {
        [Key]   
        public int MaVaiTro { get; set; }
        public string TenVaiTro { get; set; }= string.Empty;
        public string MoTa { get; set; }= string.Empty;
        public string LanCuoiCapNhat { get; set; }= string.Empty;
    }
}
