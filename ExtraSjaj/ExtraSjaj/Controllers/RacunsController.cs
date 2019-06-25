using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExtraSjaj.Common.Models;
using ExtraSjaj.DAL.Context;

namespace ExtraSjaj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacunsController : ControllerBase
    {
        private readonly ExtraSjajContext _context;

        public RacunsController(ExtraSjajContext context)
        {
            _context = context;
        }

        // GET: api/Racuns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Racun>>> GetRacuni()
        {
            return await _context.Racuni.ToListAsync();
        }

        // GET: api/Racuns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Racun>> GetRacun(int id)
        {
            var racun = await _context.Racuni.FindAsync(id);

            if (racun == null)
            {
                return NotFound();
            }

            return racun;
        }

        // PUT: api/Racuns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRacun(int id, Racun racun)
        {
            if (id != racun.Id)
            {
                return BadRequest();
            }

            _context.Entry(racun).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacunExists(id))
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

        // POST: api/Racuns
        [HttpPost]
        public async Task<ActionResult<Racun>> PostRacun(Racun racun)
        {
            _context.Racuni.Add(racun);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRacun", new { id = racun.Id }, racun);
        }

        // DELETE: api/Racuns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Racun>> DeleteRacun(int id)
        {
            var racun = await _context.Racuni.FindAsync(id);
            if (racun == null)
            {
                return NotFound();
            }

            _context.Racuni.Remove(racun);
            await _context.SaveChangesAsync();

            return racun;
        }

        private bool RacunExists(int id)
        {
            return _context.Racuni.Any(e => e.Id == id);
        }
    }
}
