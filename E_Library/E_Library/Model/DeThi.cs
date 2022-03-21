using System.ComponentModel.DataAnnotations;
namespace E_Library.Model
{
    public class DeThi
    {
        [Key]
        public int MaDeThi { get; set; }
        public string TenDeThi { get; set; } = string.Empty;
        public string TinhTrang { get; set; }= string.Empty;
        public string PheDuyet { get; set; } = string.Empty;    

    }
}
