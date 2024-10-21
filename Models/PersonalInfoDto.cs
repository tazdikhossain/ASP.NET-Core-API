namespace GCCVBUILDER.Models
{
    public class PersonalInfoDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }

        public List<EducationDto> Educations { get; set; }
        public List<ExperienceDto> Experiences { get; set; }
        public List<SkillsDto> Skills { get; set; }
    }
}
