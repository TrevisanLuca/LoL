namespace LoL.MVC.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Compositions")]
public record Composition()
{
    [Key]
    public int? Id { get; set; }

    public int TeamId { get; init; }
    [ForeignKey("TeamId")]
    public Team Team { get; init; } = null!;

    #region Legends
    //Legend 1
    public int Legend1Id { get; init; }
    public Legend Legend1 { get; init; } = null!;
    //Legend 2
    public int Legend2Id { get; init; }
    public Legend Legend2 { get; init; } = null!;
    //Legend 3
    public int Legend3Id { get; init; }
    public Legend Legend3 { get; init; } = null!;
    //Legend 4
    public int Legend4Id { get; init; }
    public Legend Legend4 { get; init; } = null!;
    //Legend 5
    public int Legend5Id { get; init; }
    public Legend Legend5 { get; init; } = null!;
    #endregion
}