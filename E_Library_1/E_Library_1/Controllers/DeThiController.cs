using E_Library_1.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN,Teacher")]
    public class DeThiController : Controller
    {
        private readonly DataContext _context;

        public DeThiController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DeThi>>> GetDeThi()
        {
            return Ok(await _context.DeThi.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<DeThi>>> PostDeThi(DeThi deThi)
        {
            _context.DeThi.Add(deThi);
            await _context.SaveChangesAsync();
            return Ok(await _context.DeThi.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<DeThi>>> UpdateDeThi(DeThi deThi)
        {
            var dbDeThi = await _context.DeThi.FindAsync(deThi.MaDeThi);
            if (dbDeThi == null)
                return BadRequest("Đề thi không Tồn Tại");
            dbDeThi.TenDeThi = deThi.TenDeThi;
            dbDeThi.ThoiLuong = deThi.ThoiLuong;
            dbDeThi.HinhThuc = deThi.HinhThuc;
            deThi.NgayTao = deThi.NgayTao;
            dbDeThi.PhanCauHoiDapAn=deThi.PhanCauHoiDapAn;
            dbDeThi.TinhTrang=deThi.TinhTrang;
            await _context.SaveChangesAsync();
            return Ok(await _context.DeThi.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<DeThi>>> DeleteDeThi(int id)
        {
            var dbDeThi = await _context.DeThi.FindAsync(id);
            if (dbDeThi == null)
                return BadRequest("Đề thi không tồn tại");
            _context.DeThi.Remove(dbDeThi);
            await _context.SaveChangesAsync();
            return Ok(await _context.DeThi.ToListAsync());
        }
    }
}
