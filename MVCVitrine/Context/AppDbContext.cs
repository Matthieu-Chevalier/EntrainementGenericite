using EntityModel.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCVitrine.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Training> Trainings { get; set; }

    }
}
