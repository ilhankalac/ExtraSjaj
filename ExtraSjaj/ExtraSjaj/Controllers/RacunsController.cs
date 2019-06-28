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

namespace ExtraSjaj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacunsController : ControllerBase
    {

        public IUnitOfWork _unitOfWork { get; }


        public RacunsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Racuns
        [HttpGet]
        public async Task<IEnumerable<Racun>> GetRacuni()
        {
            return await _unitOfWork.Racuni.GetAllAsync();
        }

        // GET: api/Racuns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Racun>> GetRacunById(int id)
        {
            var racun = await _unitOfWork.Racuni.GetAsync(id);

            if (racun == null)
            {
                return NotFound();
            }

            return racun;
        }
        // GET: api/Racuns/lista
        [HttpGet("musterija/{MusterijaId}")]
        public async Task<IEnumerable<Racun>> getRacuniByMusterijaId(int MusterijaId)
        {
            return await _unitOfWork.Racuni.getRacuniByMusterijaId(MusterijaId);
        }

        //PUT: api/Racuns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRacuns(int id, Racun racun)
        {
            if (id != racun.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Racuni.Update(racun);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacunsExists(id))
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
            
            _unitOfWork.Racuni.Add(racun);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetMusterija", new { id = racun.Id }, racun);
        }

        // DELETE: api/Racuns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Racun>> DeleteRacun(int id)
        {
            var racun = await _unitOfWork.Racuni.GetAsync(id);
            if (racun == null)
            {
                return NotFound();
            }

            _unitOfWork.Racuni.Remove(racun);
            await _unitOfWork.SaveChangesAsync();

            return racun;
        }

        private bool RacunsExists(int id)
        {
            bool isNull = true;
            var racun = _unitOfWork.Racuni.Get(id);
            if (racun != null)
                isNull = false;

            return isNull ? false : true;
        }
    }
}
