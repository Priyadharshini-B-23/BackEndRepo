using System.ComponentModel.DataAnnotations;

namespace Crud_Operations.Models
{
    public class JobSeekerSignupModel
    { 

            [Key]
            public int JobSeekerID { get; set; }
            [Required]

            public string? FirstName { get; set; }
            [Required]

            public string? LastName { get; set; }
            [Required]

            public string? JobSeekerEmailId { get; set; }
            [Required]

            public long JobSeekerPhoneNumber { get; set; }
            [Required]

            public string? JobSeekerQualification { get; set; }
            [Required]

            public string? JobSeekerPassword { get; set; }
            [Required]

            public string? JobSeekerConfirmPassword { get; set; }

       

        }
    }


