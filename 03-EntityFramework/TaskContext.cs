using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework
{
    public class TaskContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) :base(options) {}

        //Utilizando Fluent API.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(category =>
            {
                //Cambia el nombre de la tabla.
                category.ToTable("Categoria"); 

                //Establece la llave primaria.
                category.HasKey(c => c.CategoryId); 

                //Establece la propiedad como requerida y con un máximo de 50 caracteres.
                category.Property(c => c.CategoryName).IsRequired().HasMaxLength(50); 

                category.Property(c => c.Description);
            });
        
            modelBuilder.Entity<Tarea>(task => {
                
                //Cambia el nombre de la tabla.
                task.ToTable("Tarea");

                //Establece la llave primaria.
                task.HasKey(t => t.TaskId);

                //Relacion de llave foranea.
                task.HasOne(t => t.Category).WithMany(c => c.Tasks).HasForeignKey(t => t.CategoryId);

                //Establece la propiedad como requerida y con un máximo de 200 caracteres.
                task.Property(t => t.TaskName).IsRequired().HasMaxLength(200);
                
                //Propiedad Description.
                task.Property(t => t.Description);

                //Propiedad PriorityTask.
                task.Property(t => t.PriorityTask);

                //Propiedad DateCreation.
                task.Property(t => t.DateCreation);

                //Ignora la propiedad summary.
                task.Ignore(t => t.summary);

            });
        }
    }
}