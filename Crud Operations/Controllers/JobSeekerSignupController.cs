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
    public class JobSeekerSignupController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JobSeekerSignupController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/JobSeekerSignup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobSeekerSignupModel>>> GetSeekerSignup()
        {
            return await _context.SeekerSignup.ToListAsync();
        }

        // GET: api/JobSeekerSignup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobSeekerSignupModel>> GetJobSeekerSignupModel(int id)
        {
            var jobSeekerSignupModel = await _context.SeekerSignup.FindAsync(id);

            if (jobSeekerSignupModel == null)
            {
                return NotFound();
            }

            return jobSeekerSignupModel;
        }

        // PUT: api/JobSeekerSignup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobSeekerSignupModel(int id, JobSeekerSignupModel jobSeekerSignupModel)
        {
            if (id != jobSeekerSignupModel.JobSeekerID)
            {
                return BadRequest();
            }

            _context.Entry(jobSeekerSignupModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobSeekerSignupModelExists(id))
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

        // POST: api/JobSeekerSignup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobSeekerSignupModel>> PostJobSeekerSignupModel(JobSeekerSignupModel jobSeekerSignupModel)
        {
            _context.SeekerSignup.Add(jobSeekerSignupModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobSeekerSignupModel", new { id = jobSeekerSignupModel.JobSeekerID }, jobSeekerSignupModel);
        }

        // DELETE: api/JobSeekerSignup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobSeekerSignupModel(int id)
        {
            var jobSeekerSignupModel = await _context.SeekerSignup.FindAsync(id);
            if (jobSeekerSignupModel == null)
            {
                return NotFound();
            }

            _context.SeekerSignup.Remove(jobSeekerSignupModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobSeekerSignupModelExists(int id)
        {
            return _context.SeekerSignup.Any(e => e.JobSeekerID == id);
        }

    }
}