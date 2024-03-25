using Crud_Operations.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_Operations.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ProfileModel> Profile { get; set; }
        public DbSet<JobSeekerSignupModel> SeekerSignup { get; set; }
        public DbSet<JobProviderSignupModel> ProviderSignup { get; set; }
        public DbSet<JobDetailsModel> JobDetails { get; set; }
        public DbSet<ApplicationDetailsModel> ApplicationDetails { get; set; }

    }
}


