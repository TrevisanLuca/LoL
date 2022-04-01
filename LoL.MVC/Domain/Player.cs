namespace LoL.MVC.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Players")]
public record Player
(
    [Required]
    string Name = "",
    [Required]
    string Surname = "",
    [Required]
    string Nickname = "",
    [Required]
    string Nationality = "",
    [Required]
    string Category = "",
    [Required]
    DateTime BirthDay = default
)
{
    [Key]
    public int? Id { get; set; }
}