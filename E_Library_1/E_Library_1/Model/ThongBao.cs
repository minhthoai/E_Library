using System.ComponentModel.DataAnnotations;                        
namespace E_Library_1.Model
{
    public class ThongBao
    {
        [Key]
        public int MaThongBao { get; set; }
        public string TenThongBao { get; set; }= string.Empty;
        public string NoiDung { get; set; }= string.Empty;
    }
}
