namespace LoL.MVC.Models;

using Domain;

public record TeamAndPlayersViewModel
    (
    Team Team,
    IEnumerable<Player> Players
    )
{}