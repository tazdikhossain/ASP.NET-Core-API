using GCCVBUILDER.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GCCVBUILDER.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skills> Skills { get; set; }
    }
}
