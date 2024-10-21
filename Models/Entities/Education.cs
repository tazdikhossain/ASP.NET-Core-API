using System.ComponentModel.DataAnnotations;

namespace GCCVBUILDER.Models.Entities
{
    public class Education
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Institution { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Degree { get; set; }

        [Required]
        public int StartYear { get; set; }

        [Required]
        public int EndYear { get; set; }

        public string Result { get; set; }
        public string Duration { get; set; }
        public string Achievement { get; set; }

        // Foreign Key
        public int PersonalInfoId { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
    }
}
