using System.ComponentModel.DataAnnotations;
namespace E_Library_1.Model
{
    public class DeThi
    {
        [Key]
        public int MaDeThi { get; set; }
        public string TenDeThi { get; set; }=string.Empty;
        public string ThoiLuong { get; set; }   = string.Empty;
        public string HinhThuc { get; set; } = string.Empty;
        public DateTime NgayTao { get; set; }= DateTime.Now;
        public string PhanCauHoiDapAn { get; set; } = string.Empty;
        public string TinhTrang { get; set; } = string.Empty;
    }
}
