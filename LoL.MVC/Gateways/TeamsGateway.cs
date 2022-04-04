namespace LoL.MVC.Gateways;

using LoL.MVC.Abstract;
using LoL.MVC.Data;
using LoL.MVC.Domain;
using Microsoft.EntityFrameworkCore;

public class TeamsGateway : ITeamsGateway
{
    private readonly LoLDbContext _context;

    public TeamsGateway(LoLDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Team>> GetAll() => await _context.Team.ToListAsync();

    public async Task<Team?> GetById(int id) => await _context.Team.SingleOrDefaultAsync(l => l.Id == id);
    public async Task<Team> Create(Team team)
    {
        var dbEntry = await _context.AddAsync(team);
        await _context.SaveChangesAsync();
        return dbEntry.Entity;
    }
    public async Task<Team> Update(Team team)
    {
        var dbEntry = _context.Update(team);
        await _context.SaveChangesAsync();
        return dbEntry.Entity;
    }
    public async Task Delete(int id)
    {
        var newTeam = new Team()
        {
            Id = id
        };
        _context.Team.Remove(newTeam);
        await _context.SaveChangesAsync();
    }
}