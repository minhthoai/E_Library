using E_Library_1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongBaoController : ControllerBase
    {
        private readonly DataContext _context;

        public ThongBaoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ThongBao>>> GetThongBao()
        {
            return Ok(await _context.ThongBao.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<ThongBao>>> PostThongBao(ThongBao thongBao)
        {
            _context.ThongBao.Add(thongBao);
            await _context.SaveChangesAsync();
            return Ok(await _context.ThongBao.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ThongBao>>> UpdateThongBao(ThongBao thongBao)
        {
            var dbThongBao = await _context.ThongBao.FindAsync(thongBao.MaThongBao);
            if (dbThongBao == null)
                return BadRequest("Thông báo không Tồn Tại");
            dbThongBao.TenThongBao = thongBao.TenThongBao;
            dbThongBao.NoiDung = thongBao.NoiDung;
            await _context.SaveChangesAsync();
            return Ok(await _context.ThongBao.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<ThongBao>>> DeleteThongBao(int id)
        {
            var dbThongBao = await _context.ThongBao.FindAsync(id);
            if (dbThongBao == null)
                return BadRequest("Thông báo không tồn tại");
            _context.ThongBao.Remove(dbThongBao);
            await _context.SaveChangesAsync();
            return Ok(await _context.ThongBao.ToListAsync());
        }
    }
}
