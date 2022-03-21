using System.ComponentModel.DataAnnotations;
namespace E_Library.Model
{
    public class QuanLy_VaiTro
    {
        [Key]
        public int MaVaiTro { get; set; }
        public string TenVaiTro { get; set; }= string.Empty;
        public string MoTa { get; set; }= string.Empty;
        public DateTime LanCuoiCapNhat { get; set; }= DateTime.Now;
    }
}
