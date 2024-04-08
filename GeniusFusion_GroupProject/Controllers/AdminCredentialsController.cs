using GeniusFusion_GroupProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace GeniusFusion_GroupProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminCredentialsController : ControllerBase
    {
        private readonly GeniusFusionDbContext _context;

        public AdminCredentialsController(GeniusFusionDbContext context)
        {
            _context = context;
        }

        // POST: api/Admin/Register
        [HttpPost("/Admin/Register")]
        public async Task<ActionResult<AdminCredentials>> RegisterAdmin(AdminCredentials admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdmin), new { id = admin.Id }, admin);
        }

        // POST: api/Admin/Login
        [HttpPost("/Admin/Login")]
        public async Task<ActionResult<AdminCredentials>> LoginAdmin(AdminCredentials admin)
        {
            var existingAdmin = await _context.Admins.FirstOrDefaultAsync(a => a.Username == admin.Username && a.Password == admin.Password);

            if (existingAdmin == null)
            {
                return NotFound("Invalid username or password");
            }

            return Ok("Login successful");
        }

        // Helper function to check if an admin with given username exists in the database
        private bool AdminExists(string username)
        {
            return _context.Admins.Any(a => a.Username == username);
        }

        // GET: api/Admin/5
        [HttpGet("/Admin/{id}")]
        public async Task<ActionResult<AdminCredentials>> GetAdmin(int id)
        {
            var admin = await _context.Admins.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }
    }
}
