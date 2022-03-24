using E_Library_1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocController : ControllerBase
    {
        private readonly DataContext _context;

        public MonHocController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<MonHoc>>> GetMonHoc()
        {
            return Ok(await _context.MonHoc.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<MonHoc>>> PostMonHoc(MonHoc monHoc)
        {
            _context.MonHoc.Add(monHoc);
            await _context.SaveChangesAsync();
            return Ok(await _context.MonHoc.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<MonHoc>>> UpdateMonHoc(MonHoc monHoc)
        {
            var dbMonHoc = await _context.MonHoc.FindAsync(monHoc.MaMonHoc);
            if (dbMonHoc == null)
                return BadRequest("Môn học không Tồn Tại");
            dbMonHoc.TenMonHoc = monHoc.TenMonHoc;
            dbMonHoc.SoTaiLieuChoDuyet = monHoc.SoTaiLieuChoDuyet;
            dbMonHoc.TinhTrangTaiLieuMonHoc=monHoc.TinhTrangTaiLieuMonHoc;
            dbMonHoc.NgayPheDuyet=monHoc.NgayPheDuyet;
            await _context.SaveChangesAsync();
            return Ok(await _context.MonHoc.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Admin>>> DeleteMonHoc(int id)
        {
            var dbMonHoc = await _context.MonHoc.FindAsync(id);
            if (dbMonHoc == null)
                return BadRequest("Môn học không tồn tại");
            _context.MonHoc.Remove(dbMonHoc);
            await _context.SaveChangesAsync();
            return Ok(await _context.MonHoc.ToListAsync());
        }
    }
}
