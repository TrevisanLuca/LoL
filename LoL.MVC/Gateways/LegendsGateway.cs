namespace LoL.MVC.Gateways;

using Abstract;
using Domain;
using Data;
using Microsoft.EntityFrameworkCore;

public class LegendsGateway : ILegendsGateway
{
    private readonly LoLDbContext _context;

    public LegendsGateway(LoLDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Legend>> GetAll() => await _context.Legend.ToListAsync();
    public async Task<Legend?> GetById(int id) => await _context.Legend.SingleOrDefaultAsync(l => l.Id == id);
    public async Task<Legend> Create(Legend legend)
    {
        var dbEntry = await _context.AddAsync(legend);
        await _context.SaveChangesAsync();
        return dbEntry.Entity;
    }

    public async Task<Legend> Update(Legend legend)
    {
        var dbEntry = _context.Update(legend);
        await _context.SaveChangesAsync();
        return dbEntry.Entity;
    }

    public async Task Delete(int id)
    {
        var newLegend = new Legend()
        {
            Id = id
        };
        _context.Legend.Remove(newLegend);
        await _context.SaveChangesAsync();
    }
}