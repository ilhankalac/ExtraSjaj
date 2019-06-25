using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExtraSjaj.Common.Models;
using ExtraSjaj.DAL.Context;
using ExtraSjaj.Common.Interfaces;
using ExtraSjaj.DAL.RepoPattern;

namespace ExtraSjaj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusterijasController : ControllerBase
    {
        
        public IUnitOfWork _unitOfWork { get; }


        public MusterijasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Musterijas
        [HttpGet]
        public async Task<IEnumerable<Musterija>> GetMusterije()
        {
            return await _unitOfWork.Musterije.GetAllAsync();
        }

        //GET: api/Musterijas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musterija>> GetMusterija(int id)
        {
            var musterija = await _unitOfWork.Musterije.GetAsync(id);

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

            _unitOfWork.Musterije.Update(musterija);

            try
            {
                await _unitOfWork.SaveChangesAsync();
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
            _unitOfWork.Musterije.Add(musterija);
            _unitOfWork.Racuni.Add(
                new Racun()
                {
                    MusterijaId = musterija.Id,
                    BrojTepiha = 0,
                    Vrijednost = 0, 
                    Placen= false,
                    VrijemeKreiranjaRacuna = DateTime.Now
                }
            );
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetMusterija", new { id = musterija.Id }, musterija);
        }

        // DELETE: api/Musterijas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Musterija>> DeleteMusterija(int id)
        {
            var musterija = await _unitOfWork.Musterije.GetAsync(id);
            if (musterija == null)
            {
                return NotFound();
            }

            _unitOfWork.Musterije.Remove(musterija);
            await _unitOfWork.SaveChangesAsync();

            return musterija;
        }

        private bool MusterijaExists(int id)
        {
            bool isNull = true;
            var musterija = _unitOfWork.Musterije.Get(id);
            if (musterija != null)
                isNull = false;

            return isNull ? false : true;
        }
    }
}
