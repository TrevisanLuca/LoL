namespace LoL.MVC.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Games")]
public record Game
(
    [Required]
    DateTime GameDate = default
)
{
    [Key]
    public int? Id { get; set; }

    public int Team1Id { get; init; }
    public Composition Team1 { get; init; } = null!;

    public int Team2Id { get; init; }
    public Composition Team2 { get; init; } = null!;

    public int WinnerId { get; init; }
    public Team Winner { get; init; } = null!;

}