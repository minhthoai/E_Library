using System.ComponentModel.DataAnnotations;
namespace E_Library_1.Model
{
    public class Admin
    {
        [Key]
        public int MaAdmin { get; set; }
        public string TenAdmin { get; set; }= string.Empty;
    }
}
