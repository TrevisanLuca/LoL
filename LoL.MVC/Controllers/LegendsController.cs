namespace LoL.MVC.Controllers;

using Microsoft.AspNetCore.Mvc;
using Abstract;
using Domain;

public class LegendsController : Controller
{
    private readonly ILegendsGateway _legendsGateway;

    public LegendsController(ILegendsGateway legendsGateway)
    {
        _legendsGateway = legendsGateway;
    }

    public async Task<IActionResult> Index()
    {
        var legends = await _legendsGateway.GetAll();
        return View(legends);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var legend = await _legendsGateway.GetById(id);
        return legend is not null ? View(legend) : View("Error");
    }

    [HttpPost]
    public async Task<IActionResult> Create(Legend legend)
    {
        if (!ModelState.IsValid) return View();

        if (legend.Id is null)
        { await _legendsGateway.Create(legend); }
        else
        { await _legendsGateway.Update(legend); }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Create(int? id)
    {
        return id is not null ? View(await _legendsGateway.GetById((int)id)) : View();
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _legendsGateway.Delete(id);
        return RedirectToAction("Index");
    }
}