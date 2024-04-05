using GeniusFusion_GroupProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeniusFusion_GroupProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly GeniusFusionDbContext _context;

        public StudentController(GeniusFusionDbContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet("/Students")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Student/5
        [HttpGet("/Students/{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // POST: api/Student
        [HttpPost("/Students")]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, student);
        }

        //// PUT: api/Student/5
        //[HttpPut("/Students/{id}")]
        //public async Task<IActionResult> UpdateStudent(int id, Student student)
        //{
        //    if (id != student.StudentId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(student).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // PUT: api/Student/5
        [HttpPut("/Students/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student updatedStudent)
        {
            if (id != updatedStudent.StudentId)
            {
                return BadRequest();
            }

            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            // Update only the specified properties
            if (updatedStudent.StudentName != null)
            {
                existingStudent.StudentName = updatedStudent.StudentName;
            }

            if (updatedStudent.dateOfBirth != null)
            {
                existingStudent.dateOfBirth = updatedStudent.dateOfBirth;
            }

            if (updatedStudent.StudentPhone != null)
            {
                existingStudent.StudentPhone = updatedStudent.StudentPhone;
            }

            if (updatedStudent.StudentAddress != null)
            {
                existingStudent.StudentAddress = updatedStudent.StudentAddress;
            }

            if (updatedStudent.StudentEmail != null)
            {
                existingStudent.StudentEmail = updatedStudent.StudentEmail;
            }

            // Save changes to the database
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // DELETE: api/Student/5
        [HttpDelete("/Students/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Helper Function to check if the Student with given id exists in the database
        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
