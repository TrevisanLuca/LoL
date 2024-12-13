namespace LoL.MVC.Controllers;

using Microsoft.AspNetCore.Mvc;
using Abstract;
using Domain;
using Models;

public class TeamsController : Controller
{
    private readonly ITeamsGateway _teamsGateway;
    private readonly IPlayersGateway _playersGateway;

    public TeamsController(ITeamsGateway teamsGateway, IPlayersGateway playersGateway)
    {
        _teamsGateway = teamsGateway;
        _playersGateway = playersGateway;
    }

    public async Task<IActionResult> Index()
    {
        var teams = await _teamsGateway.GetAll();
        var test = await _playersGateway.GetFree(null);
        return View(teams);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var team = await _teamsGateway.GetById(id);
        var players = await _playersGateway.GetAll();
        var viewModel = new TeamAndPlayersViewModel(team, players);
        return team is not null ? View(viewModel) : View("Error");
    }

    [HttpPost]
    public async Task<IActionResult> Create(TeamCreationViewModel viewModel)
    {
        if (ModelState.IsValid is false) return View();

        if (viewModel.Team?.Id is null)
            await _teamsGateway.Create(viewModel.Team);
        else
            await _teamsGateway.Update(viewModel.Team);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Create(int? id)
    {
        var team = id is not null ? await _teamsGateway.GetById((int)id) : null;
        var players = await _playersGateway.GetFree(id);
        var viewModel = new TeamCreationViewModel(team, players);
        return View(viewModel);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _teamsGateway.Delete(id);
        return RedirectToAction("Index");
    }

}