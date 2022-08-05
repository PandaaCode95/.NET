using System.ComponentModel.DataAnnotations;

namespace UniversityBackend.Models.DataModels
{
    public class Student:BaseEntity
    {
        [Required]
        public string name { get; set; } =string.Empty;

        [Required]
        public string sname { get; set; }  =string.Empty;

        [Required]
        public DateTime birth { get; set; }

        [Required]

        public ICollection<Category> categories { get; set; } = new List<Category>();

        [Required]
        public ICollection<Student> students { get; set; } = new List<Student>();

    }
}
