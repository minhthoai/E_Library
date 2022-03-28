using E_Library_1.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN,Teacher")]
    public class TroGiupController : ControllerBase
    {
        private readonly DataContext _context;

        public TroGiupController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TroGiup>>> GetTroGiup()
        {
            return Ok(await _context.TroGiup.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<TroGiup>>> PostTroGiup(TroGiup troGiup)
        {
            _context.TroGiup.Add(troGiup);
            await _context.SaveChangesAsync();
            return Ok(await _context.TroGiup.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<TroGiup>>> UpdateTroGiup(TroGiup troGiup)
        {
            var dbTroGiup = await _context.TroGiup.FindAsync(troGiup.MaTroGiup);
            if (dbTroGiup == null)
                return BadRequest("Trợ giúp không Tồn Tại");
            dbTroGiup.TenTroGiup = troGiup.TenTroGiup;
            dbTroGiup.NoiDung=troGiup.NoiDung;
            await _context.SaveChangesAsync();
            return Ok(await _context.TroGiup.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<TroGiup>>> DeleteTroGiup(int id)
        {
            var dbTroGiup = await _context.TroGiup.FindAsync(id);
            if (dbTroGiup == null)
                return BadRequest("Trợ giúp không tồn tại");
            _context.TroGiup.Remove(dbTroGiup);
            await _context.SaveChangesAsync();
            return Ok(await _context.TroGiup.ToListAsync());
        }
    }
}
