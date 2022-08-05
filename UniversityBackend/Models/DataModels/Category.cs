using System.ComponentModel.DataAnnotations;
using UniversityBackend.Models.DataModels;

namespace UniversityBackend.Models.DataModels
{
    public class Category:BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Curso> cursos { get; set; } = new List<Curso>();
        public ICollection<Student> students { get; set; } = new List<Student>();
        
    }
}
