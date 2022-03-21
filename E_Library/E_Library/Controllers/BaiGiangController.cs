using E_Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiGiangController : Controller
    {
        private readonly DataContext _dataContext;

        public BaiGiangController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<BaiGiang>>> GetBaiGiang()
        {
            return Ok(await _dataContext.baiGiang.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<BaiGiang>>> PostBaiGiang(BaiGiang baiGiang)
        {
            _dataContext.baiGiang.Add(baiGiang);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.baiGiang.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<BaiGiang>>> PutBaiGiang(BaiGiang put)
        {
            var dbBaiGiang = await _dataContext.baiGiang.FindAsync(put.MaBaiGiang);
            if (dbBaiGiang == null)
                return BadRequest("Bai giang khong tim thay");

            dbBaiGiang.TenBaiGiang = put.TenBaiGiang;
            dbBaiGiang.Loai = put.Loai;
            dbBaiGiang.KichThuoc = put.KichThuoc;

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.baiGiang.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<BaiGiang>>> DeleteBaiGiang(int id)
        {
            var dbBaiGiang = await _dataContext.baiGiang.FindAsync(id);
            if (dbBaiGiang == null)
                return BadRequest("Bai giang khong tim thay");

            _dataContext.baiGiang.Remove(dbBaiGiang);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.baiGiang.ToListAsync());
        }
    }
}
