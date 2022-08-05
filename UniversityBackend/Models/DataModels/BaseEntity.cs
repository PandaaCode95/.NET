using System.ComponentModel.DataAnnotations;

namespace UniversityBackend.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public int userId { get; set; }


        public string CreatedBy { get; set; } = String.Empty; 
        public string? CreatedOn { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
        public User DeletedBy { get; set; } = new User();
        public DateTime? DeletedOnUtc { get; set; }
        public bool IsDeleted { get; set; }



    }
}
