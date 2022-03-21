using System.ComponentModel.DataAnnotations;
namespace E_Library.Model
{
    public class ChiTiet_DeThi
    {
        [Key]
        public int MaDeThi { get; set; }
        public int ThoiLuong { get; set; }
        public string HinhThuc { get; set; }= string.Empty;
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public string PhanCauHoi_DapAn { get; set; }= string.Empty;
    }
}
