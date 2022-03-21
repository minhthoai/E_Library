using E_Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class HeThongThuVienController : Controller
    {
        private readonly DataContext _dataContext;

        public HeThongThuVienController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<HeThongThuVien>>> GetHTTV()
        {
            return Ok(await _dataContext.heThongThuVien.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<HeThongThuVien>>> PostHTTV(HeThongThuVien httv)
        {
            _dataContext.heThongThuVien.Add(httv);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.heThongThuVien.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<HeThongThuVien>>> PutHTTV(HeThongThuVien put)
        {
            var dbHTTV = await _dataContext.heThongThuVien.FindAsync(put.MaTruongHoc);
            if (dbHTTV == null)
                return BadRequest("Ma truong khong tim thay");

            dbHTTV.TenTruong = put.TenTruong;
            dbHTTV.HieuTruong = put.HieuTruong;
            dbHTTV.LoaiTruong = put.LoaiTruong;
            dbHTTV.Email = put.Email;
            dbHTTV.Website = put.Website;
            dbHTTV.DiaChiTruyCap=put.DiaChiTruyCap;
            dbHTTV.SDT =   put.SDT;
            dbHTTV.TenHeThongThuVien = put.TenHeThongThuVien;
            dbHTTV.NgonNguXacDinh = put.NgonNguXacDinh;
            dbHTTV.NienKhoacMacDinh = put.NienKhoacMacDinh;

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.adMinQuanLy.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<AdminQuanLy>>> DeleteHTTV(int id)
        {
            var dbHTTV = await _dataContext.heThongThuVien.FindAsync(id);
            if (dbHTTV == null)
                return BadRequest("Ma truong khong tim thay");

            _dataContext.heThongThuVien.Remove(dbHTTV);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.heThongThuVien.ToListAsync());
        }
    }
}
