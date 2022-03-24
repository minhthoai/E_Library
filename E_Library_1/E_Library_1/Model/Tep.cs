using System.ComponentModel.DataAnnotations;
namespace E_Library_1.Model
{
    public class Tep
    {
        [Key]
        public int MaTep { get; set; }  
        public string TenTep { get; set; }=string.Empty;
        public string Loai { get; set; }= string.Empty;
        public DateTime NgayChinhSua { get; set; }=DateTime.Now;
    }
}
