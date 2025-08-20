using apiEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL; // Asegúrate de tener esta línea
using apiEF.Models;


var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TasksDB"));

// here the connection data
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TasksContext>(options =>
    options.UseNpgsql(connectionString)
);


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database is OK n Memory: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks);
});

app.MapGet("/api/tasks/high", async ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Where(p => p.PriorityTask == apiEF.Models.Priority.High));
});

app.MapGet("/api/tasks/highAndCategory", async ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks.Include(p=> p.Category).Where(p=> p.PriorityTask == apiEF.Models.Priority.High));
});

app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] apiEF.Models.Task task)=>
{
    task.TaskId = Guid.NewGuid();
    task.DateCreation = DateTime.UtcNow;
    await dbContext.AddAsync(task);
    // await dbContext.Tasks.AddAsync(tarea);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.Run();
