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
    public class JobProviderSignupController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JobProviderSignupController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/JobProviderSignup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobProviderSignupModel>>> GetProviderSignup()
        {
            return await _context.ProviderSignup.ToListAsync();
        }

        // GET: api/JobProviderSignup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobProviderSignupModel>> GetJobProviderSignupModel(int id)
        {
            var jobProviderSignupModel = await _context.ProviderSignup.FindAsync(id);

            if (jobProviderSignupModel == null)
            {
                return NotFound();
            }

            return jobProviderSignupModel;
        }

        // PUT: api/JobProviderSignup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobProviderSignupModel(int id, JobProviderSignupModel jobProviderSignupModel)
        {
            if (id != jobProviderSignupModel.JobProviderID)
            {
                return BadRequest();
            }

            _context.Entry(jobProviderSignupModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobProviderSignupModelExists(id))
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

        // POST: api/JobProviderSignup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobProviderSignupModel>> PostJobProviderSignupModel(JobProviderSignupModel jobProviderSignupModel)
        {
            _context.ProviderSignup.Add(jobProviderSignupModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobProviderSignupModel", new { id = jobProviderSignupModel.JobProviderID }, jobProviderSignupModel);
        }

        // DELETE: api/JobProviderSignup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobProviderSignupModel(int id)
        {
            var jobProviderSignupModel = await _context.ProviderSignup.FindAsync(id);
            if (jobProviderSignupModel == null)
            {
                return NotFound();
            }

            _context.ProviderSignup.Remove(jobProviderSignupModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobProviderSignupModelExists(int id)
        {
            return _context.ProviderSignup.Any(e => e.JobProviderID == id);
        }
    }
}
