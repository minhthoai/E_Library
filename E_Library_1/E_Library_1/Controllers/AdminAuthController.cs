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
    public class AdminAuthController : ControllerBase
    {
        public static AdminRegister admin = new AdminRegister();
        private readonly IConfiguration _configuration;

        public AdminAuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AdminRegister>> Register(AdminDTO request)
        {
            CreatePasswordHash(request.Admin_password, out byte[] admin_passwordHash, out byte[] admin_passwordSalt);

            admin.Admin_Username = request.Admin_username;
            admin.Admin_PasswordHash = admin_passwordHash;
            admin.Admin_PasswordSalt = admin_passwordSalt;

            return Ok(admin);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(AdminDTO request)
        {
            if (admin.Admin_Username != request.Admin_username)
            {
                return BadRequest("Username not found.");
            }

            if (!VerifyPasswordHash(request.Admin_password, admin.Admin_PasswordHash, admin.Admin_PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(admin);
            return Ok(token);
        }

        private string CreateToken(AdminRegister admin)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin.Admin_Username),
                new Claim(ClaimTypes.Role, "Admin")
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

        private void CreatePasswordHash(string admin_password, out byte[] admin_passwordHash, out byte[] admin_passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                admin_passwordSalt = hmac.Key;
                admin_passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(admin_password));
            }
        }

        private bool VerifyPasswordHash(string admin_password, byte[] admin_passwordHash, byte[] admin_passwordSalt)
        {
            using (var hmac = new HMACSHA512(admin_passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(admin_password));
                return computedHash.SequenceEqual(admin_passwordHash);
            }
        }
    }
}
