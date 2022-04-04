namespace LoL.MVC.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Teams")]
public record Team
(
    [Required]
    string Name = ""
)
{
    [Key]
    public int? Id { get; set; }

    #region Players
    //Player 1
    public int Player1Id { get; init; }
    public Player Player1 { get; init; } = null!;
    //Player 2
    public int Player2Id { get; init; }
    public Player Player2 { get; init; } = null!;
    //Player 3
    public int Player3Id { get; init; }
    public Player Player3 { get; init; } = null!;
    //Player 4
    public int Player4Id { get; init; }
    public Player Player4 { get; init; } = null!;
    //Player 5
    public int Player5Id { get; init; }
    public Player Player5 { get; init; } = null!;
    
    #endregion
}

