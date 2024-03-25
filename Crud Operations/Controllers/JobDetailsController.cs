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
    public class JobDetailsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JobDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/JobDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDetailsModel>>> GetJobDetails()
        {
            return await _context.JobDetails.ToListAsync();
        }

        // GET: api/JobDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDetailsModel>> GetJobDetailsModel(int id)
        {
            var jobDetailsModel = await _context.JobDetails.FindAsync(id);

            if (jobDetailsModel == null)
            {
                return NotFound();
            }

            return jobDetailsModel;
        }

        // PUT: api/JobDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobDetailsModel(int id, JobDetailsModel jobDetailsModel)
        {
            if (id != jobDetailsModel.JobID)
            {
                return BadRequest();
            }

            _context.Entry(jobDetailsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobDetailsModelExists(id))
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

        // POST: api/JobDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobDetailsModel>> PostJobDetailsModel(JobDetailsModel jobDetailsModel)
        {
            _context.JobDetails.Add(jobDetailsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobDetailsModel", new { id = jobDetailsModel.JobID }, jobDetailsModel);
        }

        // DELETE: api/JobDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobDetailsModel(int id)
        {
            var jobDetailsModel = await _context.JobDetails.FindAsync(id);
            if (jobDetailsModel == null)
            {
                return NotFound();
            }

            _context.JobDetails.Remove(jobDetailsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobDetailsModelExists(int id)
        {
            return _context.JobDetails.Any(e => e.JobID == id);
        }
    }
}
