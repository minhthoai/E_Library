using System.ComponentModel.DataAnnotations;
namespace E_Library.Model
{
    public class BaiGiang
    {
        [Key]
        public int MaBaiGiang { get; set; }
        public string TenBaiGiang { get; set; } = string.Empty;
        public string Loai { get; set; } = string.Empty;
        public string KichThuoc { get; set; }= string.Empty;
        //public int MaMonHoc { get; set; }
        //public int NguoiChinhSua { get; set; }
    }
}
