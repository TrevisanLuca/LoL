namespace LoL.MVC.Models;

using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

public class TeamCreationViewModel
{
    public Team? Team { get; set; }
    public IEnumerable<SelectListItem> Players { get; init; } = [];

    public TeamCreationViewModel()
    {

    }

    public TeamCreationViewModel(Team team, IEnumerable<Player> players)
    {
        Team = team;
        Players = players.Select(player => new SelectListItem { Value = player.Id.ToString(), Text = player.Nickname });
    }
}