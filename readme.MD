

## Models
- Creation new folder "Models".
- In "Models" 2 new files ==> Category.cs and Task.cs. This 2 are our models
- Important virtual ICollection<Task> Tasks this allow to get all task related to category
- Important virtual Category Category { get; set; } this allow to get the categoty of the task


## Tasks Context --> Entity Framework
- Creation new file in root "Taskscontext.cs"(could be in a new folder, but as is simple in the root) .
- This file is the configuration for Entity Framework for DB. 
- Important the "using Task = apiEF.Models.Task;" is needed because we have System.Threading.Tasks.Task and the Models.Task. So here we are using the Task Model.


## Data Anottation
- In the Models files ==> Category.cs and Task.cs add the "DataAnottation"
````
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
````
- This is to "import" DataAnnotation
- [Key], [Required], [MaxLength(-number here-)], ForeignKey["the key-name quoted"].
- Important [NotMapped] this is something will not be create at the start. I used in a "summary" thats is to summaried the Description. So when the thescription exist this will bet summaryzed. This is the uses for "NotMapped".


## In Memory DB test
- Just to check if everything is OK.
- In Program.cs file add all this
```
using apiEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TasksDB"));

var app = builder.Build();
```
- Then add and endpoint => "dbconexion"
````
app.MapGet("/dbconexion", async ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database is OK n Memory: " + dbContext.Database.IsInMemory());
});
````
- The run
```
dotnet build
```
- IF OK ==> then run
```
dotnet run
````
- This sould give a http://localhost:xxxx
- We check the endpoint http://localhost:xxxx/dbconexion ==> Should print ==>"Database is OK n Memory: True"



## PostgreSQL DB Connexion
- In appsetting.json add the info to connect. In my case this one.
````
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=TasksDBTester;Username=macbook;Password=123456"
  }
````
- I left a new file info-postgresql.txt in root to remember how works in my computer if you have mac and use brew this works for you.
- In Program.cs comment previous connexion ==> UseInMemoryDatabase("TasksDB") 
- In Program.cs add this connexion: 
````
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TasksContext>(options =>
    options.UseNpgsql(connectionString)
);
````
- IMPORTANT ==> Now we check the endpoint http://localhost:xxxx/dbconexion ==> Should print ==>"Database is OK n Memory: False" ==> NOW SHOULD BE FALSE. Because the endpoint is now in a real DB (postgresql).
- Also a new Folder EF-BRUNO this is where I safe the BRUNO configuration test. Bruno is like Postman or Insomnia but much simple.


## Fluent API

- This is another and more power way to manage the schemas in the DB.
- In file TasksContext.cs you find
````
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(p=> p.CategoryId);
        });

        modelBuilder.Entity<Task>(task =>
        {
            task.ToTable("Task");
            task.HasKey(p => p.TaskId);
            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
        });
        
    }
````
- With the OnModelCreating you will contrl the schema already created in de Models. 
- Now in the Models the ==>
````
[Key], [Required], [MaxLength(-number here-)], ForeignKey["the key-name quoted"].
`````
- ARE ALL COMMENTED because will be handle by "OnModelCreating(ModelBuilder modelBuilder)".
- IMPORTANT Could be not commented because OnModelCreating will override. But Good practice commented(just to remember) or delete them.