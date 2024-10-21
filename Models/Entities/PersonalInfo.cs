using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GCCVBUILDER.Models.Entities
{
    public class PersonalInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string Address { get; set; }

        [StringLength(200)]
        public string LinkedInUrl { get; set; }

        [StringLength(200)]
        public string GitHubUrl { get; set; }

        // Navigation properties
        public virtual ICollection<Education> Educations { get; set; } = new List<Education>();
        public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public virtual ICollection<Skills> Skills { get; set; } = new List<Skills>();
    }
}
