using E_Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeThiController : Controller
    {
        private readonly DataContext _dataContext;

        public DeThiController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<DeThi>>> GetDeThi()
        {
            return Ok(await _dataContext.deThi.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<DeThi>>> PostDeThi(DeThi deThi)
        {
            _dataContext.deThi.Add(deThi);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.deThi.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<DeThi>>> putDeThi(DeThi put)
        {
            var dbDT = await _dataContext.deThi.FindAsync(put.MaDeThi);
            if (dbDT == null)
                return BadRequest("De thi khong tim thay");

            dbDT.TenDeThi = put.TenDeThi;
            dbDT.TinhTrang = put.TinhTrang;
            dbDT.PheDuyet = put.PheDuyet;

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.chiTiet_deThi.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<DeThi>>> DeleteDeThi(int id)
        {
            var dbDT = await _dataContext.deThi.FindAsync(id);
            if (dbDT == null)
                return BadRequest("De thi khong tim thay");

            _dataContext.deThi.Remove(dbDT);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.deThi.ToListAsync());
        }
    }
}
