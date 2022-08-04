using System.ComponentModel.DataAnnotations;

namespace UniversityBackend.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string? CreatedOn { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime? DeletedOnUtc { get; set; }
        public bool IsDeleted { get; set; }



    }
}
