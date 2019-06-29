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
    public class UsersController : ControllerBase
    {
        public IUnitOfWork _unitOfWork { get; }


        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<User>> GetMusterije()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _unitOfWork.Users.GetAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusterija(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Users.Update(user);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {

            if ((_unitOfWork.Users.proveraJedinstvenosti(user)))
                return BadRequest();
            else
            {
                _unitOfWork.Users.Add(user);

                await _unitOfWork.SaveChangesAsync();
            }

            return  CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPost("{LoginDetail}")]
        public IActionResult LoginUser(User LoginDetail)
        {
            if (!(_unitOfWork.Users.proveraLogovanja(LoginDetail)))
                return BadRequest();
            else
                return Ok();
        }


        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _unitOfWork.Users.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _unitOfWork.Users.Remove(user);
            await _unitOfWork.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            bool isNull = true;

            var user = _unitOfWork.Users.Get(id);
            if (user != null)
                isNull = false;

            return isNull ? false : true;
        }
    }
}
