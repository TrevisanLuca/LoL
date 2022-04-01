namespace LoL.MVC.Controllers;

using Microsoft.AspNetCore.Mvc;
using Abstract;
using Domain;

public class PlayersController : Controller
{
    private readonly IPlayersGateway _playersGateway;

    public PlayersController(IPlayersGateway playersGateway)
    {
        _playersGateway = playersGateway;
    }

    public async Task<IActionResult> Index()
    {
        var player = await _playersGateway.GetAll();
        return View(player);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var player = await _playersGateway.GetById(id);
        return player is not null ? View(player) : View("Error");
    }

    [HttpPost]
    public async Task<IActionResult> Create(Player player)
    {
        if (!ModelState.IsValid) return View();

        if (player.Id is null)        
            await _playersGateway.Create(player); 
        else
            await _playersGateway.Update(player);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Create(int? id)
    {
        return id is not null ? View(await _playersGateway.GetById((int)id)) : View();
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _playersGateway.Delete(id);
        return RedirectToAction("Index");
    }
}