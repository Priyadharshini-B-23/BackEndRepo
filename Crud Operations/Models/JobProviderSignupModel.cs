using System.ComponentModel.DataAnnotations;

namespace Crud_Operations.Models
{
    public class JobProviderSignupModel
    {
      
            [Key]
            public int JobProviderID { get; set; }
            [Required]
            public string? FirstName { get; set; }
            [Required]

            public string? LastName { get; set; }
            [Required]

            public string? JobProviderEmailId { get; set; }
            [Required]

            public long JobProviderPhoneNumber { get; set; }
            [Required]

            public string? JobProviderCompanyName { get; set; }
            [Required]

            public string? JobProviderCompanyType { get; set; }
            [Required]

            public string? JobProviderLocation { get; set; }
            [Required]

            public string? JobProviderPassword { get; set; }
            [Required]


            public string? JobProviderConfirmPassword { get; set; }
        }
    }


