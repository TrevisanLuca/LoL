namespace LoL.MVC.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Legends")]
public record Legend
(
    [Required]
    string Name = "",
    [Required]
    string Category = "",
    [Required]
    string Bio = ""
)
{
    [Key]
    public int? Id { get; set; }
}