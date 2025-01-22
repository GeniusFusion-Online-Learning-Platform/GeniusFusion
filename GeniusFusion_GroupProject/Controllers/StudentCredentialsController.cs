using GeniusFusion_GroupProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace GeniusFusion_GroupProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCredentialsController : ControllerBase
    {
        private readonly GeniusFusionDbContext _context;

        public StudentCredentialsController(GeniusFusionDbContext context)
        {
            _context = context;
        }

        // POST: api/StudentCredentials/Register
        [HttpPost("/Student/Register")]
        public async Task<ActionResult<StudentCredentials>> RegisterStudent(StudentCredentials student)
        {
            _context.StudentCredentials.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentCredentialsId }, student);
        }

        // POST: api/StudentCredentials/Login
        [HttpPost("/Student/Login")]
        public async Task<ActionResult<StudentCredentials>> LoginStudent(StudentCredentials student)
        {
            var existingStudent = await _context.StudentCredentials.FirstOrDefaultAsync(s => s.Username == student.Username && s.Password == student.Password);

            if (existingStudent == null)
            {
                return NotFound("Invalid username or password");
            }

            return Ok("Login successful");
        }

        // Helper function to check if a student with the given username exists in the database
        private bool StudentExists(string username)
        {
            return _context.StudentCredentials.Any(s => s.Username == username);
        }

        // GET: api/StudentCredentials/5
        [HttpGet("/Student/{id}")]
        public async Task<ActionResult<StudentCredentials>> GetStudent(int id)
        {
            var student = await _context.StudentCredentials.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }
    }
}
