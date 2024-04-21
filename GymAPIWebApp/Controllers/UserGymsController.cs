﻿using System;
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
    public class UserGymsController : ControllerBase
    {
        private readonly GymAPIContext _context;

        public UserGymsController(GymAPIContext context)
        {
            _context = context;
        }

        // GET: api/UserGyms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGym>>> GetUserGyms()
        {
            return await _context.UserGyms.ToListAsync();
        }

        // GET: api/UserGyms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGym>> GetUserGym(int id)
        {
            var userGym = await _context.UserGyms.FindAsync(id);

            if (userGym == null)
            {
                return NotFound();
            }

            return userGym;
        }

        // PUT: api/UserGyms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserGym(int id, UserGym userGym)
        {
            if (id != userGym.Id)
            {
                return BadRequest();
            }

            _context.Entry(userGym).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGymExists(id))
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

        // POST: api/UserGyms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserGym>> PostUserGym(UserGym userGym)
        {
            _context.UserGyms.Add(userGym);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserGym", new { id = userGym.Id }, userGym);
        }

        // DELETE: api/UserGyms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserGym(int id)
        {
            var userGym = await _context.UserGyms.FindAsync(id);
            if (userGym == null)
            {
                return NotFound();
            }

            _context.UserGyms.Remove(userGym);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserGymExists(int id)
        {
            return _context.UserGyms.Any(e => e.Id == id);
        }
    }
}
