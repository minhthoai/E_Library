using System.ComponentModel.DataAnnotations;
namespace E_Library_1.Model
{
    public class TroGiup
    {
        [Key]
        public int MaTroGiup { get; set; }
        public string TenTroGiup { get; set; }= string.Empty;
        public string NoiDung { get; set; }= string.Empty;
    }

}
