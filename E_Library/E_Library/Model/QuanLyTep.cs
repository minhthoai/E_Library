using System.ComponentModel.DataAnnotations;
namespace E_Library.Model
{
    public class QuanLyTep
    {
        [Key]
        public int MaTep { get; set; }
        public string TenTep { get; set; }= string.Empty;
        public string TheLoai { get; set; }= string.Empty;
        public DateTime NgayChinhSua { get; set; }= DateTime.Now;
        public string KichThuoc { get; set; } = string.Empty;
    }
}
