
using GeniusFusion_GroupProject.Entities;
using GeniusFusion_GroupProject.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GeniusFusion_GroupProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : Controller
    {

        private readonly GeniusFusionDbContext _context;

        public EnrollmentController(GeniusFusionDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/Enrollments")]
        public async Task<ActionResult<Enrollment>> EnrollStudent(EnrollmentRequest enrollmentRequest)
        {
            // Log the received enrollment request
            Console.WriteLine($"Received enrollment request - StudentId: {enrollmentRequest.StudentId}, CourseName: {enrollmentRequest.CourseName}");

            // Check if the course exists
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseName == enrollmentRequest.CourseName);
            if (course == null)
            {
                Console.WriteLine($"Course '{enrollmentRequest.CourseName}' not found.");
                return BadRequest("Course not found.");
            }

            // Check if the student exists
            var student = await _context.Students.FindAsync(enrollmentRequest.StudentId);
            if (student == null)
            {
                Console.WriteLine($"Student with ID '{enrollmentRequest.StudentId}' not found.");
                return BadRequest("Student not found.");
            }

            // Check if the student is already enrolled in the course
            if (_context.Enrollments.Any(e => e.CourseId == course.CourseId && e.StudentId == enrollmentRequest.StudentId))
            {
                Console.WriteLine($"Student with ID '{enrollmentRequest.StudentId}' is already enrolled in the course '{course.CourseName}'.");
                return BadRequest("Student is already enrolled in the course.");
            }

            // Create a new enrollment
            var enrollment = new Enrollment
            {
                CourseId = course.CourseId,
                StudentId = enrollmentRequest.StudentId
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            Console.WriteLine($"Student with ID '{enrollmentRequest.StudentId}' successfully enrolled in the course '{course.CourseName}'.");

            return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.EnrollmentId }, enrollment);
        }


        // Helper method to get an enrollment by ID
        private async Task<ActionResult<Enrollment>> GetEnrollment(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return enrollment;
        }
    }
}
