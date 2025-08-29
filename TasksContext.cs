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
        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(new Category() { CategoryId = Guid.Parse("00f9d419-1430-4312-bfe3-834e5f8727ca"), Name = "Outdoor activities", Relevance = 40 });
        categoriesInit.Add(new Category() { CategoryId = Guid.Parse("00f9d419-1430-4312-bfe3-834e5f8727cb"), Name = "Indoor activities", Relevance = 15 });

        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(p => p.CategoryId);

            category.Property(p => p.Name).IsRequired().HasMaxLength(170);

            category.Property(p => p.Description).IsRequired(false);

            category.Property(p => p.Relevance);

            category.HasData(categoriesInit);
        });

        DateTime staticDate = new DateTime(2025, 8, 16, 18, 0, 0, DateTimeKind.Utc);

        List<Task> tasksInit = new List<Task>();
        tasksInit.Add(new Task() { TaskId = Guid.Parse("00f9d419-1430-4312-bfe3-834e5f872710"), CategoryId = Guid.Parse("00f9d419-1430-4312-bfe3-834e5f8727ca"), Title = "Run 20 min", PriorityTask = Priority.High, DateCreation = staticDate });
        tasksInit.Add(new Task() { TaskId = Guid.Parse("00f9d419-1430-4312-bfe3-834e5f872712"), CategoryId = Guid.Parse("00f9d419-1430-4312-bfe3-834e5f8727ca"), Title = "Climb Everest", PriorityTask = Priority.Low, DateCreation = staticDate });
        tasksInit.Add(new Task() { TaskId = Guid.Parse("00f9d419-1430-4312-bfe3-834e5f872714"), CategoryId = Guid.Parse("00f9d419-1430-4312-bfe3-834e5f8727cb"), Title = "Play Chess", PriorityTask = Priority.Medium, DateCreation = staticDate });
        tasksInit.Add(new Task() { TaskId = Guid.Parse("00f9d419-1430-4312-bfe3-834e5f872716"), CategoryId = Guid.Parse("00f9d419-1430-4312-bfe3-834e5f8727cb"), Title = "Clean under the bed", PriorityTask = Priority.Low, DateCreation = staticDate });

        modelBuilder.Entity<Task>(task =>
        {
            task.ToTable("Task");
            task.HasKey(p => p.TaskId);

            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);

            task.Property(p => p.Title).IsRequired().HasMaxLength(210);

            task.Property(p => p.Description).IsRequired(false);

            task.Property(p => p.PriorityTask);

            task.Property(p => p.DateCreation);

            task.Ignore(p => p.Summary);

            task.HasData(tasksInit);
        });
        
    }
}

