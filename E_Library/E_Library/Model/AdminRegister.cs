namespace E_Library.Model
{
    public class AdminRegister
    {
        public string admin_username { get; set; } = string.Empty;
        public byte [] admin_passwordhash { get; set; }
        public byte [] admin_passwordsalt { get; set; }
    }
}
