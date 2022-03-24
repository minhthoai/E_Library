using Microsoft.AspNetCore.Mvc;
using E_Library_1.Model;
using Microsoft.AspNetCore.Authorization;

namespace E_Library_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BaiGiangController : Controller
    {
        private readonly DataContext _context;

        public BaiGiangController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<BaiGiang>>> GetBaiGiang()
        {
            return Ok(await _context.BaiGiang.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<BaiGiang>>> PostBaiGiang(BaiGiang baiGiang)
        {
            _context.BaiGiang.Add(baiGiang);
            await _context.SaveChangesAsync();
            return Ok(await _context.BaiGiang.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<BaiGiang>>> UpdateBaiGiang(BaiGiang baiGiang)
        {
            var dbBaiGiang = await _context.BaiGiang.FindAsync(baiGiang.MaBaiGiang);
            if (dbBaiGiang == null)
                return BadRequest("Bài giảng không Tồn Tại");
            dbBaiGiang.TenBaiGiang = baiGiang.TenBaiGiang;
            dbBaiGiang.Loai=baiGiang.Loai;
            dbBaiGiang.KichThuoc= baiGiang.KichThuoc;
            await _context.SaveChangesAsync();
            return Ok(await _context.BaiGiang.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Admin>>> DeleteAdmin(int id)
        {
            var dbBaiGiang = await _context.BaiGiang.FindAsync(id);
            if (dbBaiGiang == null)
                return BadRequest("Bài giảng không tồn tại");
            _context.BaiGiang.Remove(dbBaiGiang);
            await _context.SaveChangesAsync();
            return Ok(await _context.BaiGiang.ToListAsync());
        }
    }
}
