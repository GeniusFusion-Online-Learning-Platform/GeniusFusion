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
    public class FacultyCredentialsController : ControllerBase
    {
        private readonly GeniusFusionDbContext _context;

        public FacultyCredentialsController(GeniusFusionDbContext context)
        {
            _context = context;
        }

        // POST: api/FacultyCredentials/Register
        [HttpPost("Register")]
        public async Task<ActionResult<FacultyCredentials>> RegisterFaculty(FacultyCredentials faculty)
        {
            _context.facultyCredentials.Add(faculty);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFaculty), new { id = faculty.Id }, faculty);
        }

        // POST: api/FacultyCredentials/Login
        [HttpPost("Login")]
        public async Task<ActionResult<FacultyCredentials>> LoginFaculty(FacultyCredentials faculty)
        {
            var existingFaculty = await _context.facultyCredentials.FirstOrDefaultAsync(f => f.Username == faculty.Username && f.Password == faculty.Password);

            if (existingFaculty == null)
            {
                return NotFound("Invalid username or password");
            }

            return Ok("Login successful");
        }

        // Helper function to check if a faculty with the given username exists in the database
        private bool FacultyExists(string username)
        {
            return _context.facultyCredentials.Any(f => f.Username == username);
        }

        // GET: api/FacultyCredentials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacultyCredentials>> GetFaculty(int id)
        {
            var faculty = await _context.facultyCredentials.FindAsync(id);

            if (faculty == null)
            {
                return NotFound();
            }

            return faculty;
        }
    }
}
