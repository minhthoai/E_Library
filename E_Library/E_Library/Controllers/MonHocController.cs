using E_Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocController : Controller
    {

        private readonly DataContext _dataContext;

        public MonHocController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<MonHoc>>> GetMonHoc()
        {
            return Ok(await _dataContext.monHoc.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<MonHoc>>> PostMonHoc(MonHoc monHoc)
        {
            _dataContext.monHoc.Add(monHoc);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.monHoc.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<MonHoc>>> PutAdminQuanLy(MonHoc put)
        {
            var dbMh = await _dataContext.monHoc.FindAsync(put.MaMonHoc);
            if (dbMh == null)
                return BadRequest("Mon hoc khong tim thay");

            dbMh.TenMonHoc = put.TenMonHoc;
            dbMh.SoTaiLieuChoDuyet = put.SoTaiLieuChoDuyet;
            dbMh.TinhTrangTaiLieuMonHoc = put.TinhTrangTaiLieuMonHoc;
            dbMh.NgayPheDuyet = put.NgayPheDuyet;

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.monHoc.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<MonHoc>>> DeleteMonHoc(int id)
        {
            var dbMh = await _dataContext.monHoc.FindAsync(id);
            if (dbMh == null)
                return BadRequest("Mon hoc khong tim thay");

            _dataContext.monHoc.Remove(dbMh);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.monHoc.ToListAsync());
        }
    }
}
