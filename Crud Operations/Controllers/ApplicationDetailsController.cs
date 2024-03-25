using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crud_Operations.Data;
using Crud_Operations.Models;

namespace Crud_Operations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationDetailsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApplicationDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationDetailsModel>>> GetApplicationDetails()
        {
            return await _context.ApplicationDetails.ToListAsync();
        }

        // GET: api/ApplicationDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationDetailsModel>> GetApplicationDetailsModel(int id)
        {
            var applicationDetailsModel = await _context.ApplicationDetails.FindAsync(id);

            if (applicationDetailsModel == null)
            {
                return NotFound();
            }

            return applicationDetailsModel;
        }

        // PUT: api/ApplicationDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationDetailsModel(int id, ApplicationDetailsModel applicationDetailsModel)
        {
            if (id != applicationDetailsModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(applicationDetailsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationDetailsModelExists(id))
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

        // POST: api/ApplicationDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApplicationDetailsModel>> PostApplicationDetailsModel(ApplicationDetailsModel applicationDetailsModel)
        {
            _context.ApplicationDetails.Add(applicationDetailsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplicationDetailsModel", new { id = applicationDetailsModel.ID }, applicationDetailsModel);
        }

        // DELETE: api/ApplicationDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationDetailsModel(int id)
        {
            var applicationDetailsModel = await _context.ApplicationDetails.FindAsync(id);
            if (applicationDetailsModel == null)
            {
                return NotFound();
            }

            _context.ApplicationDetails.Remove(applicationDetailsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationDetailsModelExists(int id)
        {
            return _context.ApplicationDetails.Any(e => e.ID == id);
        }
    }
}
