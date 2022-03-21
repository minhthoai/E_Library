using E_Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLy_VaiTRoController : Controller
    {

        private readonly DataContext _dataContext;

        public QuanLy_VaiTRoController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<QuanLy_VaiTro>>> GetQLVT()
        {
            return Ok(await _dataContext.quanLy_VaiTro.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<QuanLy_VaiTro>>> PostQuanLy_VaiTro(QuanLy_VaiTro qlvt)
        {
            _dataContext.quanLy_VaiTro.Add(qlvt);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.quanLy_VaiTro.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<QuanLy_VaiTro>>> PutQuanLy_VaiTro(QuanLy_VaiTro put)
        {
            var dbQLVT = await _dataContext.quanLy_VaiTro.FindAsync(put.MaVaiTro);
            if (dbQLVT == null)
                return BadRequest("Vai tro khong tim thay");

            dbQLVT.TenVaiTro = put.TenVaiTro;
            dbQLVT.MoTa = put.MoTa;
            dbQLVT.LanCuoiCapNhat = put.LanCuoiCapNhat;

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.quanLy_VaiTro.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<QuanLy_VaiTro>>> DeleteQuanLy_VaiTro(int id)
        {
            var dbQLVT = await _dataContext.quanLy_VaiTro.FindAsync(id);
            if (dbQLVT == null)
                return BadRequest("Vai tro khong tim thay");

            _dataContext.quanLy_VaiTro.Remove(dbQLVT);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.quanLy_VaiTro.ToListAsync());
        }
    }
}
