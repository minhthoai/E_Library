using System.ComponentModel.DataAnnotations;
namespace E_Library_1.Model
{
    public class TaiLieu
    {
        [Key]
        public int MaTaiLieu { get; set; }
        public string TenTaiLieu { set; get; }= string.Empty;
        public string Loai { set; get; }= string.Empty;
        public string TinhTrang { set; get; }= string.Empty;
        public DateTime NgayGui { get; set; } = DateTime.Now;
    }
}
