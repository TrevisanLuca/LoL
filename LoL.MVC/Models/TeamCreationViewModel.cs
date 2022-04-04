namespace LoL.MVC.Models;

using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

public class TeamCreationViewModel
{
    public Team? Team { get; set; }
    public IEnumerable<SelectListItem> Players { get; init; }

    public TeamCreationViewModel()
    {

    }

    public TeamCreationViewModel(Team team, IEnumerable<Player> players)
    {
        Team = team;
        var vaffa = new List<SelectListItem>();
        foreach (var player in players)
        {
            vaffa.Add(new SelectListItem { Value = player.Id.ToString(), Text = player.Nickname });
        }
        Players = vaffa;
    }
}