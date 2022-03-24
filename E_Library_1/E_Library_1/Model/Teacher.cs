using System.ComponentModel.DataAnnotations;
namespace E_Library_1.Model
{
    public class Teacher
    {
        [Key]
        public int MaTeacher { get; set; }
        public string TenTeacher { set; get; }= string.Empty;
        public DateTime NgaySinh { get; set; }= DateTime.Now;
        public string NoiSinh { get; set; }= string.Empty;
        public string Email { get; set; }= string.Empty;
        public int SDT { get; set; }
        public string TrinhDo { get; set; }= string.Empty;
    }
}
