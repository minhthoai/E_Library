using Microsoft.AspNetCore.Mvc;
using E_Library.Model;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTiet_DeThiController : Controller
    {
        private readonly DataContext _dataContext;

        public ChiTiet_DeThiController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChiTiet_DeThi>>> GetChiTiet_DeThi()
        {
            return Ok(await _dataContext.chiTiet_deThi.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<ChiTiet_DeThi>>> PostChiTiet_DeThi(ChiTiet_DeThi ctdt)
        {
            _dataContext.chiTiet_deThi.Add(ctdt);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.chiTiet_deThi.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ChiTiet_DeThi>>> PutChiTiet_DeThi(ChiTiet_DeThi put)
        {
            var dbCTDT = await _dataContext.chiTiet_deThi.FindAsync(put.MaDeThi);
            if (dbCTDT == null)
                return BadRequest("Chi tiet de thi khong tim thay");

            dbCTDT.ThoiLuong = put.ThoiLuong;
            dbCTDT.HinhThuc = put.HinhThuc;
            dbCTDT.NgayTao = put.NgayTao;
            dbCTDT.PhanCauHoi_DapAn = put.PhanCauHoi_DapAn;

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.chiTiet_deThi.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ChiTiet_DeThi>>> DeleteChiTiet_DeThi(int id)
        {
            var dbCTDT = await _dataContext.chiTiet_deThi.FindAsync(id);
            if (dbCTDT == null)
                return BadRequest("Chi tiet de thi khong tim thay");

            _dataContext.chiTiet_deThi.Remove(dbCTDT);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.chiTiet_deThi.ToListAsync());
        }
    }
}
