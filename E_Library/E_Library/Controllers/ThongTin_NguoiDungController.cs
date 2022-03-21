using E_Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTin_NguoiDungController : Controller
    {
        private readonly DataContext _dataContext;

        public ThongTin_NguoiDungController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ThongTin_NguoiDung>>> GetThongTin_NguoiDung()
        {
            return Ok(await _dataContext.thongTin_NguoiDung.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<ThongTin_NguoiDung>>> PostThongTin_NguoiDung(ThongTin_NguoiDung ttnd)
        {
            _dataContext.thongTin_NguoiDung.Add(ttnd);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.thongTin_NguoiDung.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ThongTin_NguoiDung>>> PutThongTin_NguoiDung(ThongTin_NguoiDung put)
        {
            var dbTTND = await _dataContext.thongTin_NguoiDung.FindAsync(put.MaNguoiDung);
            if (dbTTND == null)
                return BadRequest("Nguoi dung nay khong tim thay");

            dbTTND.TenNguoiDung = put.TenNguoiDung;
            dbTTND.Email = put.Email;
            dbTTND.VaiTro=put.VaiTro;

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.thongTin_NguoiDung.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ThongTin_NguoiDung>>> DeleteThongTin_NguoiDung(int id)
        {
            var dbTTND = await _dataContext.thongTin_NguoiDung.FindAsync(id);
            if (dbTTND == null)
                return BadRequest("Nguoi dung nay khong tim thay");

            _dataContext.thongTin_NguoiDung.Remove(dbTTND);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.thongTin_NguoiDung.ToListAsync());
        }
    }
}
