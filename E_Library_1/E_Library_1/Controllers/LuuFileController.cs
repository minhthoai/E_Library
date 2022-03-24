using E_Library_1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuuFileController : ControllerBase
    {
        private readonly DataContext _context;

        public LuuFileController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<LuuFile>>> GetLuuFile()
        {
            return Ok(await _context.LuuFile.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<LuuFile>>> PostAdmin(LuuFile luuFile)
        {
            _context.LuuFile.Add(luuFile);
            await _context.SaveChangesAsync();
            return Ok(await _context.LuuFile.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<LuuFile>>> UpdateLuuFile(LuuFile luuFile)
        {
            var dbLuuFile = await _context.LuuFile.FindAsync(luuFile.MaFile);
            if (dbLuuFile == null)
                return BadRequest("File không Tồn Tại");
            dbLuuFile.TenFile = luuFile.TenFile;
            dbLuuFile.LoaiFile= luuFile.LoaiFile;
            dbLuuFile.ViTri= luuFile.ViTri;
            dbLuuFile.NoiDung = luuFile.NoiDung;
            await _context.SaveChangesAsync();
            return Ok(await _context.LuuFile.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Admin>>> DeleteAdmin(int id)
        {
            var dbLuuFile = await _context.LuuFile.FindAsync(id);
            if (dbLuuFile == null)
                return BadRequest("File không tồn tại");
            _context.LuuFile.Remove(dbLuuFile);
            await _context.SaveChangesAsync();
            return Ok(await _context.LuuFile.ToListAsync());
        }
    }
}
