using E_Library.Model;
using Microsoft.AspNetCore.Mvc;


namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLyTepController : Controller
    {
        private readonly DataContext _dataContext;

        public QuanLyTepController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<QuanLyTep>>> GetQLTep()
        {
            return Ok(await _dataContext.quanLyTep.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<QuanLyTep>>> PostQuanLyTep(QuanLyTep qltep)
        {
            _dataContext.quanLyTep.Add(qltep);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.quanLyTep.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<QuanLyTep>>> PutQuanLyTep(QuanLyTep put)
        {
            var dbQLTep = await _dataContext.quanLyTep.FindAsync(put.MaTep);
            if (dbQLTep == null)
                return BadRequest("Tep khong tim thay");

            dbQLTep.TenTep = put.TenTep ;
            dbQLTep.TheLoai = put.TheLoai;
            dbQLTep.NgayChinhSua = put.NgayChinhSua;
            dbQLTep.KichThuoc=put.KichThuoc;

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.quanLyTep.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<QuanLyTep>>> DeleteQuanLyTep(int id)
        {
            var dbQLTep = await _dataContext.quanLyTep.FindAsync(id);
            if (dbQLTep == null)
                return BadRequest("Tep khong tim thay");

            _dataContext.quanLyTep.Remove(dbQLTep);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.quanLyTep.ToListAsync());
        }
    }
}
