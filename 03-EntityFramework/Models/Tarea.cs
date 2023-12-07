using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EntityFramework.Models
{
    public class Tarea
    {
        // [Key]
        public int TaskId { get; set; }

        // [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        // [Required]
        // [MaxLength(200)]
        public string TaskName { get; set; }

        public string Description { get; set; }

        public Priority PriorityTask { get; set; }

        public DateTime DateCreation { get; set; }

        public virtual Category Category { get; set; }

        // [NotMapped]
        public string summary { get; set; }

    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}