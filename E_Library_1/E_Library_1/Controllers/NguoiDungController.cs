using E_Library_1.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN,Teacher")]
    public class NguoiDungController : ControllerBase
    {
        private readonly DataContext _context;

        public NguoiDungController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<NguoiDung>>> GetNguoiDung()
        {
            return Ok(await _context.NguoiDung.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<NguoiDung>>> PostNguoiDung(NguoiDung nguoiDung)
        {
            _context.NguoiDung.Add(nguoiDung);
            await _context.SaveChangesAsync();
            return Ok(await _context.NguoiDung.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<NguoiDung>>> UpdateNguoiDung(NguoiDung nguoiDung)
        {
            var dbNguoiDung = await _context.NguoiDung.FindAsync(nguoiDung.MaNguoiDung);
            if (dbNguoiDung == null)
                return BadRequest("Người dùng không Tồn Tại");
            dbNguoiDung.TenNguoiDung = nguoiDung.TenNguoiDung;
            dbNguoiDung.Email = nguoiDung.Email;
            dbNguoiDung.VaiTro=nguoiDung.VaiTro;
            await _context.SaveChangesAsync();
            return Ok(await _context.NguoiDung.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<NguoiDung>>> DeleteNguoiDung(int id)
        {
            var dbNguoiDung = await _context.NguoiDung.FindAsync(id);
            if (dbNguoiDung == null)
                return BadRequest("Người dùng không tồn tại");
            _context.NguoiDung.Remove(dbNguoiDung);
            await _context.SaveChangesAsync();
            return Ok(await _context.NguoiDung.ToListAsync());
        }
    }
}
