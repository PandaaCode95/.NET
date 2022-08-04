using System.ComponentModel.DataAnnotations;

namespace UniversityBackend.Models.DataModels
{
    public class User :BaseEntity
    {
        [Required, StringLength(50)]
        public string name { get; set; } = string.Empty;
        
        [Required, StringLength(100)]
        public string sname { get; set; } = string.Empty;   
        [Required, EmailAddress]
        public string email { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;

    }
}
