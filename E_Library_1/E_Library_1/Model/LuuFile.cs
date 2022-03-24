using System.ComponentModel.DataAnnotations;
namespace E_Library_1.Model
{
    public class LuuFile
    {
        [Key]
        public int MaFile { get; set; }
        public string TenFile { get; set; }=string.Empty;
        public string LoaiFile { get; set; }    = string.Empty;
        public string ViTri { get; set; }= string.Empty;
        public string NoiDung { get; set; } = string.Empty;
    }
}
