using Microsoft.EntityFrameworkCore;
using apiEF.Models;
using Task = apiEF.Models.Task; 
// the above is needed because 'Task' is an ambiguous reference between 'apiEF.Models.Task' and 'System.Threading.Tasks.Task'CS0104

namespace apiEF;

public class TasksContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }
}

