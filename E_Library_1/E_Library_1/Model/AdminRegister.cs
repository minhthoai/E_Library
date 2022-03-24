namespace E_Library_1.Model
{
    public class AdminRegister
    {
        public string Admin_Username { get; set; }= string.Empty;
        public byte[] Admin_PasswordHash { get; set; }
        public byte[] Admin_PasswordSalt { get; set; 
        }
    }
}
