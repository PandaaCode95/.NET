using Microsoft.EntityFrameworkCore;
using UniversityBackend.Models.DataModels;

namespace UniversityBackend.DataAcces
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
        {

        }
        public DbSet<User>? Users { get; set; }
        public DbSet<Curso>? Curso { get; set; }
    }
}
