using E_Library.Data;
using E_Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly DataContext _dataContext;

        public AdminController (DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdminQuanLy>>> GetAdmin()
        {
            return Ok(await _dataContext.adMinQuanLy.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<AdminQuanLy>>> PostAdminQuanLy(AdminQuanLy admin)
        {
            _dataContext.adMinQuanLy.Add(admin);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.adMinQuanLy.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<AdminQuanLy>>> PutAdminQuanLy(AdminQuanLy put)
        {
            var dbAmin = await _dataContext.adMinQuanLy.FindAsync(put.maAdmin);
            if (dbAmin == null)
                return BadRequest("Admin khong tim thay");

            dbAmin.tenAdmin=put.tenAdmin;
            dbAmin.taiKhoanAdmin=put.taiKhoanAdmin;
            dbAmin.maAdmin=put.maAdmin;

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.adMinQuanLy.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<AdminQuanLy>>> DeleteAdminQuanLy(int id)
        {
            var dbAdmin = await _dataContext.adMinQuanLy.FindAsync(id);
            if (dbAdmin == null)
                return BadRequest("Admin khong tim thay");

            _dataContext.adMinQuanLy.Remove(dbAdmin);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.adMinQuanLy.ToListAsync());
        }
    }
}
