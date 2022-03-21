using E_Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiLieuController : Controller
    {
        private readonly DataContext _dataContext;

        public TaiLieuController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaiLieu>>> GetTaiLieu()
        {
            return Ok(await _dataContext.taiLieu.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<TaiLieu>>> PostTaiLieu(TaiLieu taiLieu)
        {
            _dataContext.taiLieu.Add(taiLieu);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.taiLieu.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<TaiLieu>>> PutTaiLieu(TaiLieu put)
        {
            var dbtaiLieu = await _dataContext.taiLieu.FindAsync(put.MaTaiLieu);
            if (dbtaiLieu == null)
                return BadRequest("Tai lieu khong tim thay");

            dbtaiLieu.TenTaiLieu = put.TenTaiLieu;
            dbtaiLieu.Loai = put.Loai;
            dbtaiLieu.NgayGui = put.NgayGui;
            dbtaiLieu.TinhTrang=put.TinhTrang;

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.taiLieu.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TaiLieu>>> DeleteTaiLieu(int id)
        {
            var dbtaiLieu = await _dataContext.taiLieu.FindAsync(id);
            if (dbtaiLieu == null)
                return BadRequest("Tai lieu khong tim thay");

            _dataContext.taiLieu.Remove(dbtaiLieu);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.taiLieu.ToListAsync());
        }
    }
}
