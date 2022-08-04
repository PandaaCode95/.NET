using System.ComponentModel.DataAnnotations;

namespace UniversityBackend.Models.DataModels
{
    public enum Nivel { Basico, Intermedio, Avanzado};
    public class Curso
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

    }
}
