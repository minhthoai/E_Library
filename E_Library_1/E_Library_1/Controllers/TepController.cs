using E_Library_1.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN,Teacher")]
    public class TepController : ControllerBase
    {
        private readonly DataContext _context;

        public TepController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tep>>> GetTep()
        {
            return Ok(await _context.Tep.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Tep>>> PostTep(Tep tep)
        {
            _context.Tep.Add(tep);
            await _context.SaveChangesAsync();
            return Ok(await _context.Tep.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Tep>>> UpdateTep(Tep tep)
        {
            var dbTep = await _context.Tep.FindAsync(tep.MaTep);
            if (dbTep == null)
                return BadRequest("Tệp không Tồn Tại");
            dbTep.TenTep = tep.TenTep;
            dbTep.Loai=tep.Loai;
            dbTep.NgayChinhSua=tep.NgayChinhSua;
            await _context.SaveChangesAsync();
            return Ok(await _context.Tep.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Tep>>> DeleteTep(int id)
        {
            var dbTep = await _context.Tep.FindAsync(id);
            if (dbTep == null)
                return BadRequest("Tệp không tồn tại");
            _context.Tep.Remove(dbTep);
            await _context.SaveChangesAsync();
            return Ok(await _context.Tep.ToListAsync());
        }
    }
}
