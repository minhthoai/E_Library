using E_Library_1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiNguyenController : ControllerBase
    {
        private readonly DataContext _context;

        public TaiNguyenController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaiNguyen>>> GetTaiNguyen()
        {
            return Ok(await _context.TaiNguyen.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<TaiNguyen>>> PostTaiNguyen(TaiNguyen taiNguyen)
        {
            _context.TaiNguyen.Add(taiNguyen);
            await _context.SaveChangesAsync();
            return Ok(await _context.TaiNguyen.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<TaiNguyen>>> UpdateTaiNguyen(TaiNguyen taiNguyen)
        {
            var dbTaiNguyen = await _context.TaiNguyen.FindAsync(taiNguyen.MaTaiNguyen);
            if (dbTaiNguyen == null)
                return BadRequest("Tài nguyên không Tồn Tại");
            dbTaiNguyen.TenTaiNguyen = taiNguyen.TenTaiNguyen;
            dbTaiNguyen.Loai=taiNguyen.Loai;
            dbTaiNguyen.KichThuoc=taiNguyen.KichThuoc;
            await _context.SaveChangesAsync();
            return Ok(await _context.TaiNguyen.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<TaiNguyen>>> DeleteTaiNguyen(int id)
        {
            var dbTaiNguyen = await _context.TaiNguyen.FindAsync(id);
            if (dbTaiNguyen == null)
                return BadRequest("Tài nguyên không tồn tại");
            _context.TaiNguyen.Remove(dbTaiNguyen);
            await _context.SaveChangesAsync();
            return Ok(await _context.TaiNguyen.ToListAsync());
        }
    }
}
