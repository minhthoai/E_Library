using E_Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly DataContext _dataContext;

        public TeacherController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> GetTeacher()
        {
            return Ok(await _dataContext.teacher.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Teacher>>> PostTeacher(Teacher teacher)
        {
            _dataContext.teacher.Add(teacher);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.teacher.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Teacher>>> PutTeacher(Teacher put)
        {
            var dbteaCher = await _dataContext.teacher.FindAsync(put.MaTeacher);
            if (dbteaCher == null)
                return BadRequest("Teacher nay khong tim thay");

            dbteaCher.TenTeacher = put.TenTeacher;
            dbteaCher.NgaySinh = put.NgaySinh;
            dbteaCher.NoiSinh = put.NoiSinh;
            dbteaCher.Email = put.Email;
            dbteaCher.SDT=put.SDT;
            dbteaCher.TrinhDo= put.TrinhDo;

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.teacher.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Teacher>>> DeleteTeacher(int id)
        {
            var dbteaCher = await _dataContext.teacher.FindAsync(id);
            if (dbteaCher == null)
                return BadRequest("Teacher nay khong tim thay");

            _dataContext.teacher.Remove(dbteaCher);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.teacher.ToListAsync());
        }
    }
}
