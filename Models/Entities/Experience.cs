using System.ComponentModel.DataAnnotations;

namespace GCCVBUILDER.Models.Entities
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string JobTitle { get; set; }

        [Required]
        public int StartYear { get; set; }

        public int? EndYear { get; set; }

        // Foreign Key
        public int PersonalInfoId { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
    }
}
