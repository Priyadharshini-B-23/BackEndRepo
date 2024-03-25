using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crud_Operations.Models
{
    public class JobDetailsModel
    {
 
            [Key]

            public int JobID { get; set; }
            [Required]

            public string? JobName { get; set; }
            [Required]

            public string? Role { get; set; }
            [Required]

            public string? CompanyName { get; set; }
            [Required]


            public string? CompanyType { get; set; }
            [Required]

            public string? Location { get; set; }
            [Required]

            public string? Description { get; set; }
            [Required]

            public string? AboutCompany { get; set; }
            [Required]

            public int salary { get; set; }
            [Required]

            public string? EmployeeType { get; set; }
            public int JobProviderID { get; set; }
        }
    }

