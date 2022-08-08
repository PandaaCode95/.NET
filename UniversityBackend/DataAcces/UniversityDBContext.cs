using Microsoft.EntityFrameworkCore;
using UniversityBackend.Models.DataModels;

namespace UniversityBackend.DataAcces
{
    public class UniversityDBContext : DbContext
    {

        private readonly ILoggerFactory _loggerFactory;
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Curso>? Curso { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }
        public DbSet<Student>? Students { get; set; }
        
        protected void OnConFiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = _loggerFactory.CreateLogger<UniversityDBContext>();
            optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }));
            optionsBuilder.EnableSensitiveDataLogging();
        }
    
    }
}
