using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using E_Library_1.Model;


namespace E_Library_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAuthController : ControllerBase
    {
        public static TeacherRegister teacher = new TeacherRegister();
        private readonly IConfiguration _configuration;

        public TeacherAuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<TeacherRegister>> Register(TeacherDTO request)
        {
            CreatePasswordHash(request.teacher_Password, out byte[] teacher_passwordHash, out byte[] teacher_passwordSalt);

            teacher.teacher_Username = request.teacher_Username;
            teacher.teacher_PasswordHash = teacher_passwordHash;
            teacher.teacher_PasswordSalt = teacher_passwordSalt;

            return Ok(teacher);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(TeacherDTO request)
        {
            if (teacher.teacher_Username != request.teacher_Username)
            {
                return BadRequest("Username not found.");
            }

            if (!VerifyPasswordHash(request.teacher_Password, teacher.teacher_PasswordHash, teacher.teacher_PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(teacher);
            return Ok(token);
        }

        private string CreateToken(TeacherRegister teacher)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, teacher.teacher_Username),
                new Claim(ClaimTypes.Role, "Teacher")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
