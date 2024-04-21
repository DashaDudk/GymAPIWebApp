using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymAPIWebApp.Models;

namespace GymAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GymAPIContext _context;

        public CategoriesController(GymAPIContext context)
        {
            _context = context;
        }

        // GET: api/Types
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetTypes()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET: api/Types/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetType(int id)
        {
            var @type = await _context.Categories.FindAsync(id);

            if (@type == null)
            {
                return NotFound();
            }

            return @type;
        }

        // PUT: api/Types/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category @category)
        {
            if (id != @category.Id)
            {
                return BadRequest();
            }

            _context.Entry(@category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(id))
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

        // POST: api/Types
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostType(Category @category)
        {
            _context.Categories.Add(@category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = @category.Id }, @category);
        }

        // DELETE: api/Types/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var @category = await _context. Categories.FindAsync(id);
            if (@category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(@category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
