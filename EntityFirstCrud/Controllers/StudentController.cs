using EntityFirstCrud.DataAccess;
using EntityFirstCrud.Models;
using EntityFirstCrud.StudentDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFirstCrud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private AppDbContext context;

        public StudentController(AppDbContext dbContext)
        {
            context = dbContext;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateStudentAsync(StudentDto studentdto)
        {
            var students = new Student
            {
                FirstName = studentdto.FirstName,
                LastName = studentdto.LastName,
                Year = (studentdto.Year),
            };
            await context.Students.AddAsync(students);
            await context.SaveChangesAsync();

            return Ok("Student Added");
        }

        [HttpPatch]
        public async ValueTask<IActionResult> UpdateStudentAsync(int Id, string NewName)
        {
            var result = await context.Students.FirstOrDefaultAsync(x => x.Id == Id);
            if (result != null)
            {
                result.FirstName = NewName;
                //context.Students.Update(result);
                await context.SaveChangesAsync();
            }
            else
                return Ok("User not found");
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteStudent(int Id)
        {
            var result = await context.Students.FirstOrDefaultAsync(x => x.Id == Id);
            if (result != null)
            {
                context.Students.Remove(result);
                await context.SaveChangesAsync();
            }
            else
                return Ok("User not found");
            return Ok("Deleted");
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var result = context.Students.AsNoTracking().ToList();

            return Ok(result);
        }


    }
}
