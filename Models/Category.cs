using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace apiEF.Models;

public class Category
{
    // [Key]
    public Guid CategoryId { get; set; }

    // [Required]
    // [MaxLength(180)]
    public string Name { get; set; }
    public string Description { get; set; }

    [JsonIgnore]
    public virtual ICollection<Task> Tasks { get; set; }
    public int Relevance { get; set; }
}