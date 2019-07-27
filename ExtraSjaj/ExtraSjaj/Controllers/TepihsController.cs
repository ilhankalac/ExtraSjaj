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
    public class TepihsController : ControllerBase
    {
        public IUnitOfWork _unitOfWork { get; }


        public TepihsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/Tepihs
        [HttpGet]
        public async Task<IEnumerable<Tepih>> GetTepisi()
        {
            return await _unitOfWork.Tepisi.GetAllAsync();
        }

        // GET: api/Tepihs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tepih>> GetTepihById(int id)
        {
            var tepih = await _unitOfWork.Tepisi.GetAsync(id);

            if (tepih == null)
            {
                return NotFound();
            }

            return tepih;
        }

        [HttpGet("Racun/{RacunId}")]
        public async Task<IEnumerable<Tepih>> GetTepisiByRacunId(int RacunId)
        {
            return await _unitOfWork.Tepisi.GetTepisiByRacunIdReversed(RacunId);
        }

        // PUT: api/Tepihs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTepih(int id, Tepih tepih)
        {
            if (id != tepih.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Tepisi.Update(tepih);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TepihsExists(id))
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


        // POST: api/Tepihs
        [HttpPost]
        public async Task<IActionResult> PostTepih(Tepih tepih)
        {

            tepih.Duzina = Math.Round(tepih.Duzina, 2);
            tepih.Sirina = Math.Round(tepih.Sirina, 2);
            tepih.Kvadratura = Math.Round((tepih.Duzina * tepih.Sirina),2);

            _unitOfWork.Tepisi.Add(tepih);

            await _unitOfWork.SaveChangesAsync();


            _unitOfWork.Racuni.tepihAkcija(tepih);

            return Ok(tepih);
        }


        // DELETE: api/Tepihs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tepih>> DeleteTepih(int id)
        {
            var tepih = await _unitOfWork.Tepisi.GetAsync(id);
            if (tepih == null)
            {
                return NotFound();
            }

            _unitOfWork.Tepisi.Remove(tepih);
            await _unitOfWork.SaveChangesAsync();

            _unitOfWork.Racuni.tepihAkcija(tepih);

            return tepih;
        }


        private bool TepihsExists(int id)
        {
            bool isNull = true;
            var tepih = _unitOfWork.Tepisi.Get(id);
            if (tepih != null)
                isNull = false;

            return isNull ? false : true;
        }
    }
}
