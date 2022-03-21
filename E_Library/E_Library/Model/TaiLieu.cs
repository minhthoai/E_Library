using System.ComponentModel.DataAnnotations;
namespace E_Library.Model
{
    public class TaiLieu
    {
        [Key]
        public int MaTaiLieu { get; set; }
        public string TenTaiLieu { set; get; }=string.Empty;
        public string Loai { set; get; }=string.Empty;
        public DateTime NgayGui { set; get; }=DateTime.Now;
        public string TinhTrang { set; get; }=string.Empty;
    }
}
