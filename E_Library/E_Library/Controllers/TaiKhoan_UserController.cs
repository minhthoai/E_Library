using E_Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoan_UserController : Controller
    {
        private readonly DataContext _dataContext;

        public TaiKhoan_UserController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaiKhoan_User>>> GetTaiKhoanUser()
        {
            return Ok(await _dataContext.taiKhoan_User.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<TaiKhoan_User>>> PostTaiKhoanUser(TaiKhoan_User tkuser)
        {
            _dataContext.taiKhoan_User.Add(tkuser);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.taiKhoan_User.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<TaiKhoan_User>>> PutTaiKhoanUser(TaiKhoan_User put)
        {
            var dbtkUser = await _dataContext.taiKhoan_User.FindAsync(put.MaTaiKhoan);
            if (dbtkUser == null)
                return BadRequest("Tai khoan user khong tim thay");

            dbtkUser.TenTaiKhoan = put.TenTaiKhoan;
            dbtkUser.MatKhau = put.MatKhau;

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.taiKhoan_User.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TaiKhoan_User>>> DeleteTaiKhoanUser(int id)
        {
            var dbtkUser = await _dataContext.taiKhoan_User.FindAsync(id);
            if (dbtkUser == null)
                return BadRequest("Tai khoan user khong tim thay");

            _dataContext.taiKhoan_User.Remove(dbtkUser);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.taiKhoan_User.ToListAsync());
        }
    }
}
