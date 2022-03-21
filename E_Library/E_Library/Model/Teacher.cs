using System.ComponentModel.DataAnnotations;
namespace E_Library.Model
{
    public class Teacher
    {
        [Key]
        public int MaTeacher { get; set; }
        public string TenTeacher { get; set; }=string.Empty;
        public DateTime NgaySinh { get; set; }= DateTime.Now;
        public string NoiSinh { get; set; }=string.Empty;
        public string Email { get; set; }=string.Empty;
        public int SDT { get; set; }=int.MaxValue;
        public string TrinhDo { get; set; } = string.Empty;
    }
}
