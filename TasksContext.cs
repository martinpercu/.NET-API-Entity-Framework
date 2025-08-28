using Microsoft.EntityFrameworkCore;
using apiEF.Models;
using Task = apiEF.Models.Task;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
// the above is needed because 'Task' is an ambiguous reference between 'apiEF.Models.Task' and 'System.Threading.Tasks.Task'CS0104

namespace apiEF;

public class TasksContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(p=> p.CategoryId);

            category.Property(p=> p.Name).IsRequired().HasMaxLength(170);

            category.Property(p=> p.Description);
            
            category.Property(p=> p.Relevance);
        });

        modelBuilder.Entity<Task>(task =>
        {
            task.ToTable("Task");
            task.HasKey(p => p.TaskId);

            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);

            task.Property(p => p.Title).IsRequired().HasMaxLength(210);

            task.Property(p => p.Description);

            task.Property(p => p.PriorityTask);

            task.Property(p => p.DateCreation);

            task.Ignore(p => p.Summary);
        });
        
    }
}

