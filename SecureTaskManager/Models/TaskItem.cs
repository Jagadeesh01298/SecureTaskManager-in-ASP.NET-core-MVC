using System.ComponentModel.DataAnnotations;

namespace SecureTaskManager.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public string UserId { get; set; } = string.Empty;
    }
}
