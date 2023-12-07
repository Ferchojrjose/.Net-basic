using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models
{
    public class Category
    {
        // [Key]
        public int CategoryId { get; set; }

        // [Required]
        // [MaxLength(150)]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Tarea> Tasks { get; set; }

    }
}