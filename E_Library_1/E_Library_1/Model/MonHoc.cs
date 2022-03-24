using System.ComponentModel.DataAnnotations;
namespace E_Library_1.Model
{
    public class MonHoc
    {
        [Key]
        public int MaMonHoc { get; set; }   
        public string TenMonHoc { get; set; }= string.Empty;
        public string SoTaiLieuChoDuyet { get; set; }= string.Empty;
        public string TinhTrangTaiLieuMonHoc { get; set; }= string.Empty;
        public DateTime NgayPheDuyet { get; set; }= DateTime.Now;
    }
}
