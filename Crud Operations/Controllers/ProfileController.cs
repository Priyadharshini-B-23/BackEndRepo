using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crud_Operations.Data;
using Crud_Operations.Models;
using System.Text;

namespace Crud_Operations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Profile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileModel>>> GetProfile()
        {
            return await _context.Profile.ToListAsync();
        }

        // GET: api/Profile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileModel>> GetProfileModel(int id)
        {
            var profileModel = await _context.Profile.FindAsync(id);

            if (profileModel == null)
            {
                return NotFound();
            }

            return profileModel;
        }

        // PUT: api/Profile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfileModel(int id, ProfileModel profileModel)
        {
            if (id != profileModel.JobSeekerRegistrationID)
            {
                return BadRequest();
            }

            _context.Entry(profileModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileModelExists(id))
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

        [HttpPost]
        public async Task<IActionResult> Upload(ProfileModel profile)
        {

  


            byte[] byteArray = Encoding.ASCII.GetBytes(profile!.Resume!);
            ProfileModel profilemodel = new ProfileModel() {
                
              JobSeekerRegistrationID = profile.JobSeekerRegistrationID,
            FirstName = profile.FirstName,
           LastName = profile.LastName,
            EmailId = profile.EmailId,
           Qualification = profile.Qualification,
            Experience = profile.Experience,
            TenthPercentage = profile.TenthPercentage,
            TwelvethPercentage = profile.TwelvethPercentage,
            CGPA = profile.CGPA,
            PhoneNumber = profile.PhoneNumber,
            SkillSet = profile.SkillSet,
            Location = profile.Location,
            Resume = byteArray.ToString(),
            UniqueFileName = profile.UniqueFileName,
            JobSeekerSignUpModel = profile.JobSeekerSignUpModel
        };
            await _context.Profile.AddAsync(profilemodel);
            await _context.SaveChangesAsync();
            return Ok("Products added");
        }


        // DELETE: api/Profile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfileModel(int id)
        {
            var profileModel = await _context.Profile.FindAsync(id);
            if (profileModel == null)
            {
                return NotFound();
            }

            _context.Profile.Remove(profileModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileModelExists(int id)
        {
            return _context.Profile.Any(e => e.JobSeekerRegistrationID == id);
        }
    }
}
