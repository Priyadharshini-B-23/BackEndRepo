using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crud_Operations.Models
{
    public class ApplicationDetailsModel
  
  
        {
            [Key]
            public int ID { get; set; }
            public int JobID { get; set; }

            [Required]
            public string? JobProviderName { get; set; }
            [Required]

            public string? PreferredLocation { get; set; }
            
            public int JobSeekerID { get; set; }
        }
    }


