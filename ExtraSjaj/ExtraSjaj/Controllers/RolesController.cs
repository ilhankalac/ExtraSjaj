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
    public class RolesController : ControllerBase
    {
        public IUnitOfWork _unitOfWork { get; }


        public RolesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/Roles
        [HttpGet]
        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _unitOfWork.Roles.GetAllAsync();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _unitOfWork.Roles.GetAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }


        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Roles.Update(role);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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


        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            _unitOfWork.Roles.Add(role);

            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetRole", new { id = role.Id }, role);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Role>> DeleteRole(int id)
        {
            var role = await _unitOfWork.Roles.GetAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _unitOfWork.Roles.Remove(role);
            await _unitOfWork.SaveChangesAsync();

            return role;
        }


        private bool RoleExists(int id)
        {
            bool isNull = true;

            var role = _unitOfWork.Roles.Get(id);
            if (role != null)
                isNull = false;

            return isNull ? false : true;
        }
    }
}
