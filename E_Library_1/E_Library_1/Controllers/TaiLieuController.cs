using E_Library_1.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN,Teacher")]
    public class TaiLieuController : ControllerBase
    {
        private readonly DataContext _context;

        public TaiLieuController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaiLieu>>> GetTaiLieu()
        {
            return Ok(await _context.TaiLieu.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<TaiLieu>>> PostTaiLieu(TaiLieu taiLieu)
        {
            _context.TaiLieu.Add(taiLieu);
            await _context.SaveChangesAsync();
            return Ok(await _context.TaiLieu.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<TaiLieu>>> UpdateTaiLieu(TaiLieu taiLieu)
        {
            var dbTaiLieu = await _context.TaiLieu.FindAsync(taiLieu.MaTaiLieu);
            if (dbTaiLieu == null)
                return BadRequest("Tài liệu không Tồn Tại");
            dbTaiLieu.TenTaiLieu = taiLieu.TenTaiLieu;
            dbTaiLieu.Loai=taiLieu.Loai;
            dbTaiLieu.TinhTrang=taiLieu.TinhTrang;
            dbTaiLieu.NgayGui=taiLieu.NgayGui;
            await _context.SaveChangesAsync();
            return Ok(await _context.TaiLieu.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<TaiLieu>>> DeleteTaiLieu(int id)
        {
            var dbTaiLieu = await _context.TaiLieu.FindAsync(id);
            if (dbTaiLieu == null)
                return BadRequest("Tài liệu không tồn tại");
            _context.TaiLieu.Remove(dbTaiLieu);
            await _context.SaveChangesAsync();
            return Ok(await _context.TaiLieu.ToListAsync());
        }
    }
}
