﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBFirst_Bus.Models;

namespace DBFirst_Bus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private readonly BusContext _context;

        public BusesController(BusContext context)
        {
            _context = context;
        }

        // GET: api/Buses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bus>>> GetBuses()
        {
          if (_context.Buses == null)
          {
              return NotFound();
          }
            return await _context.Buses.ToListAsync();
        }

        // GET: api/Buses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bus>> GetBus(string id)
        {
          if (_context.Buses == null)
          {
              return NotFound();
          }
            var bus = await _context.Buses.FindAsync(id);

            if (bus == null)
            {
                return NotFound();
            }

            return bus;
        }

        // PUT: api/Buses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBus(string id, Bus bus)
        {
            if (id != bus.BusName)
            {
                return BadRequest();
            }

            _context.Entry(bus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusExists(id))
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

        // POST: api/Buses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bus>> PostBus(Bus bus)
        {
          if (_context.Buses == null)
          {
              return Problem("Entity set 'BusContext.Buses'  is null.");
          }
            _context.Buses.Add(bus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BusExists(bus.BusName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBus", new { id = bus.BusName }, bus);
        }

        // DELETE: api/Buses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBus(string id)
        {
            if (_context.Buses == null)
            {
                return NotFound();
            }
            var bus = await _context.Buses.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }

            _context.Buses.Remove(bus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusExists(string id)
        {
            return (_context.Buses?.Any(e => e.BusName == id)).GetValueOrDefault();
        }
    }
}
