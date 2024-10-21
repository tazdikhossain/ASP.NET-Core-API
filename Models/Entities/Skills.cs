using System.ComponentModel.DataAnnotations;

namespace GCCVBUILDER.Models.Entities
{
    public class Skills
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Language { get; set; }

        [Required]
        public string Reading { get; set; }

        [Required]
        public string Writing { get; set; }

        [Required]
        public string Speaking { get; set; }

        // Foreign Key
        public int PersonalInfoId { get; set; }
        public virtual PersonalInfo PersonalInfo { get; set; }
    }
}
