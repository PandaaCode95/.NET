using System.ComponentModel.DataAnnotations;

namespace UniversityBackend.Models.DataModels
{
    public class Chapter:BaseEntity
    {
        public int cursoId { get; set; }
        public virtual Curso Curso { get; set; } = new Curso();
        [Required]
        public string title = string.Empty;

    }
}
