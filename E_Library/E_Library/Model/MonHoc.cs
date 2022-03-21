using System.ComponentModel.DataAnnotations;
namespace E_Library.Model
{
    public class MonHoc
    {
        [Key]
        public int MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }=  string.Empty;
        public int SoTaiLieuChoDuyet { get; set; }
        public string TinhTrangTaiLieuMonHoc { get; set; }= string.Empty;
        public DateTime NgayPheDuyet { get; set; }= DateTime.Now;
        //public int MaTeacher { get; set; }
    }
}
