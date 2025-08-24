

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