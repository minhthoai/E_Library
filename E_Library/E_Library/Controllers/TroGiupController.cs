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
    public class TroGiupController : Controller
    {
        private readonly DataContext _context;
        public TroGiupController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<TroGiup>>> GetTroGiup()
        {
            return Ok(await _context.troGiup.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<TroGiup>>> PostTroGiup(TroGiup troGiup)
        {
            _context.troGiup.Add(troGiup);
            await _context.SaveChangesAsync();
            return Ok(await _context.troGiup.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<TroGiup>>> PutTroGiup(TroGiup troGiup)
        {
            var dbTroGiup = await _context.troGiup.FindAsync(troGiup.MaTroGiup);
            if (dbTroGiup == null)
                return BadRequest("Khong tim thay tro giup");
            dbTroGiup.TenTroGiup = troGiup.TenTroGiup;
            dbTroGiup.NoiDung = troGiup.NoiDung;

            await _context.SaveChangesAsync();
            return Ok(await _context.troGiup.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TroGiup>>> DeleteTroGiup(int id)
        {
            var dbTroGiup = await _context.troGiup.FindAsync(id);
            if (dbTroGiup == null)
                return BadRequest("Tro giup khong tim thay");
            _context.troGiup.Remove(dbTroGiup);
            await _context.SaveChangesAsync();

            return Ok(await _context.troGiup.ToListAsync());
        }
    }
}
