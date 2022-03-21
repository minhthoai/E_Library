using System.ComponentModel.DataAnnotations;
namespace E_Library.Model
{
    public class TaiNguyen
    {
        [Key]
        public int MaTaiNguyen { get; set; }
        public string TenTaiNguyen { get; set; }=string.Empty;
        public string Loai { get; set; }= string.Empty;
        public string KichThuoc { get; set; }= string.Empty;
    }
}
