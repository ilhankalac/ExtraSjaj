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
    public class MusterijasController : ControllerBase
    {
        private readonly ExtraSjajContext _context;

        public MusterijasController(ExtraSjajContext context)
        {
            _context = context;
        }

        // GET: api/Musterijas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musterija>>> GetMusterije()
        {
            return await _context.Musterije.ToListAsync();
        }

        // GET: api/Musterijas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musterija>> GetMusterija(int id)
        {
            var musterija = await _context.Musterije.FindAsync(id);

            if (musterija == null)
            {
                return NotFound();
            }

            return musterija;
        }

        // PUT: api/Musterijas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusterija(int id, Musterija musterija)
        {
            if (id != musterija.Id)
            {
                return BadRequest();
            }

            _context.Entry(musterija).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusterijaExists(id))
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

        // POST: api/Musterijas
        [HttpPost]
        public async Task<ActionResult<Musterija>> PostMusterija(Musterija musterija)
        {
            musterija.VrijemeKreiranjaMusterije = DateTime.Now;
            _context.Musterije.Add(musterija);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusterija", new { id = musterija.Id }, musterija);
        }

        // DELETE: api/Musterijas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Musterija>> DeleteMusterija(int id)
        {
            var musterija = await _context.Musterije.FindAsync(id);
            if (musterija == null)
            {
                return NotFound();
            }

            _context.Musterije.Remove(musterija);
            await _context.SaveChangesAsync();

            return musterija;
        }

        private bool MusterijaExists(int id)
        {
            return _context.Musterije.Any(e => e.Id == id);
        }
    }
}
