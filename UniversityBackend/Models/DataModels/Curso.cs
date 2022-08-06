using System.ComponentModel.DataAnnotations;

namespace UniversityBackend.Models.DataModels
{
    public enum Nivel { Basico, Intermedio, Avanzado};
    public class Curso: BaseEntity
    {

        [Required, StringLength(50)]
        public string name { get; set; }= string.Empty;
        [Required, StringLength(280)]

        public string description { get; set; }= string.Empty;
        [Required]
        public string LongDescription { get; set; }= string.Empty;
        [Required]
        public string publicObjetivo { get; set; }= string.Empty;
        [Required]
        public string objetivos { get; set; }= string.Empty;    
        [Required]
        public string requisitos { get; set; }= string.Empty;
        
        [Required]
        public Nivel level { get; set; } = 0;

        [Required]
        public ICollection<Category> categories { get; set; } = new List<Category>();
        [Required]
        public ICollection<Student> students { get; set; } = new List<Student>();

        [Required]
        public Chapter chapter { get; set; }= new Chapter();
    }
}
