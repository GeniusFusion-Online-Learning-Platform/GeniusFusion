
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
    public class FacultyController : ControllerBase
    {
        private readonly GeniusFusionDbContext _context;

        public FacultyController(GeniusFusionDbContext context)
        {
            _context = context;
        }

        // GET: api/Faculty
        [HttpGet("/Faculties")]
        public async Task<ActionResult<IEnumerable<Faculty>>> GetFaculties()
        {
            return await _context.Faculties.ToListAsync();
        }

        // GET: api/Faculty/5
        [HttpGet("/Faculties/{id}")]
        public async Task<ActionResult<Faculty>> GetFaculty(int id)
        {
            var faculty = await _context.Faculties.FindAsync(id);

            if (faculty == null)
            {
                return NotFound();
            }

            return faculty;
        }

        // POST: api/Faculty
        [HttpPost("/Faculties")]
        public async Task<ActionResult<Faculty>> CreateFaculty(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFaculty), new { id = faculty.FacultyId }, faculty);
        }

        // PUT: api/Faculty/5
        [HttpPut("/Faculties/{id}")]
        public async Task<IActionResult> UpdateFaculty(int id, Faculty updatedFaculty)
        {
            if (id != updatedFaculty.FacultyId)
            {
                return BadRequest();
            }

            var existingFaculty = await _context.Faculties.FindAsync(id);
            if (existingFaculty == null)
            {
                return NotFound();
            }

            // Update only the specified properties
            if (updatedFaculty.FacultyName != null)
            {
                existingFaculty.FacultyName = updatedFaculty.FacultyName;
            }

            if (updatedFaculty.dateOfBirth != null)
            {
                existingFaculty.dateOfBirth = updatedFaculty.dateOfBirth;
            }

            if (updatedFaculty.FacultyPhone != null)
            {
                existingFaculty.FacultyPhone = updatedFaculty.FacultyPhone;
            }

            if (updatedFaculty.FacultyAddress != null)
            {
                existingFaculty.FacultyAddress = updatedFaculty.FacultyAddress;
            }

            if (updatedFaculty.FacultyEmail != null)
            {
                existingFaculty.FacultyEmail = updatedFaculty.FacultyEmail;
            }

            // Save changes to the database
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacultyExists(id))
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


        // DELETE: api/Faculty/5
        [HttpDelete("/Faculties/{id}")]
        public async Task<IActionResult> DeleteFaculty(int id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }

            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacultyExists(int id)
        {
            return _context.Faculties.Any(e => e.FacultyId == id);
        }
    }
}
    

