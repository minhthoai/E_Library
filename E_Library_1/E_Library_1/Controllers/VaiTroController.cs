using E_Library_1.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN,Teacher")]
    public class VaiTroController : ControllerBase
    {
        private readonly DataContext _context;

        public VaiTroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<VaiTro>>> GetVaiTro()
        {
            return Ok(await _context.VaiTro.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<VaiTro>>> PostVaiTro(VaiTro vaiTro)
        {
            _context.VaiTro.Add(vaiTro);
            await _context.SaveChangesAsync();
            return Ok(await _context.VaiTro.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<VaiTro>>> UpdateVaiTro(VaiTro vaiTro)
        {
            var dbVaiTro = await _context.VaiTro.FindAsync(vaiTro.MaVaiTro);
            if (dbVaiTro == null)
                return BadRequest("Vai trò không Tồn Tại");
            dbVaiTro.TenVaiTro = vaiTro.TenVaiTro;
            dbVaiTro.MoTa = vaiTro.MoTa;
            dbVaiTro.LanCuoiCapNhat= vaiTro.LanCuoiCapNhat;
            await _context.SaveChangesAsync();
            return Ok(await _context.VaiTro.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<VaiTro>>> DeleteVaiTro(int id)
        {
            var dbVaiTro = await _context.VaiTro.FindAsync(id);
            if (dbVaiTro == null)
                return BadRequest("Vai trò không tồn tại");
            _context.VaiTro.Remove(dbVaiTro);
            await _context.SaveChangesAsync();
            return Ok(await _context.VaiTro.ToListAsync());
        }
    }

}
