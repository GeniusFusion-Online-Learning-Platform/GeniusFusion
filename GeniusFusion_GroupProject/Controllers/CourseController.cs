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
    public class CourseController : ControllerBase
    {
        private readonly GeniusFusionDbContext _context;

        public CourseController(GeniusFusionDbContext context)
        {
            _context = context;
        }

        // GET: api/Course
        [HttpGet("/Course")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.Include(e=> e.Enrollments).ToListAsync();
        }

        // GET: api/Course/5
        [HttpGet("/Course/{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // POST: api/Course
        [HttpPost("/Course")]
        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            // Check if the provided FacultyId corresponds to an existing faculty
            var existingFaculty = await _context.Faculties.FindAsync(course.FacultyId);
            if (existingFaculty == null)
            {
                return BadRequest("Faculty not found."); // Return a 400 Bad Request if the faculty does not exist
            }

            // If the faculty exists, proceed with creating the course
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourse), new { id = course.CourseId }, course);
        }

        // PUT: api/Course/5
        [HttpPut("/Course/{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // DELETE: api/Course/5
        [HttpDelete("/Course/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("/Course/{id}/Students")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsEnrolledInCourse(int id)
        {
            var course = await _context.Courses.Include(c => c.Enrollments).ThenInclude(e => e.Student).FirstOrDefaultAsync(c => c.CourseId == id);

            if (course == null)
            {
                return NotFound("Course not found.");
            }

            var students = course.Enrollments.Select(e => e.Student).ToList();
            return students;
        }


        [HttpGet("/Faculties/{facultyId}/Courses")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByFaculty(int facultyId)
        {
            // Retrieve the faculty by ID including their courses
            var faculty = await _context.Faculties
                .Include(f => f.CoursesTaught)
                .ThenInclude(c => c.Enrollments)
                .FirstOrDefaultAsync(f => f.FacultyId == facultyId);

            if (faculty == null)
            {
                return NotFound("Faculty not found.");
            }

            // Return the list of courses taught by the faculty
            return faculty.CoursesTaught.ToList();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
 