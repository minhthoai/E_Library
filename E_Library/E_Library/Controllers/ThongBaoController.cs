using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using E_Library.Model;
using E_Library.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongBaoController : Controller
    {
        private readonly DataContext _context;
        public ThongBaoController (DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<ThongBao>>> GetThongBao()
        {
            return Ok(await _context.thongBaos.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<ThongBao>>> PostThongBao(ThongBao thongBao)
        {
            _context.thongBaos.Add(thongBao);
            await _context.SaveChangesAsync();
            return Ok(await _context.thongBaos.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<ThongBao>>> PutThongBao(ThongBao thongBao)
        {
            var dbThongbao = await _context.thongBaos.FindAsync(thongBao.MaThongBao);
            if (dbThongbao == null)
                return BadRequest("Khong tim thay thong bao");
            dbThongbao.TenThongBao = thongBao.TenThongBao;
            dbThongbao.NoiDung = thongBao.NoiDung;

            await _context.SaveChangesAsync();
            return Ok(await _context.thongBaos.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ThongBao>>> DeleteThongBao(int id)
        {
            var dbThongbao= await _context.thongBaos.FindAsync(id);
            if (dbThongbao == null)
                return BadRequest("Thong bao khong tim thay");
            _context.thongBaos.Remove(dbThongbao);
            await _context.SaveChangesAsync();
             
            return Ok(await _context.thongBaos.ToListAsync());
        }
    }
}
