using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class ToDoEntry
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string? EntryText { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime CreatedBy { get; set; }

        public DateTime? ExpiresBy { get; set; }
    }
}
