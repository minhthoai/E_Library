namespace E_Library_1.Model
{
    public class TeacherRegister
    {
        public string teacher_Username { get; set; }= string.Empty;
        public byte[] teacher_PasswordHash { get; set; }
        public byte[] teacher_PasswordSalt { get; set; }
    }
}
