

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