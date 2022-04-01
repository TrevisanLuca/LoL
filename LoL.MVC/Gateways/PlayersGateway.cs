namespace LoL.MVC.Gateways;

using Abstract;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
public class PlayersGateway : IPlayersGateway
{
    private readonly LoLDbContext _context;
    public PlayersGateway(LoLDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Player>> GetAll() => await _context.Player.ToListAsync();

    public async Task<Player?> GetById(int id) => await _context.Player.SingleOrDefaultAsync(p => p.Id == id);
    public async Task<Player> Create(Player player)
    {
        var dbEntry = await _context.AddAsync(player);
        await _context.SaveChangesAsync();
        return dbEntry.Entity;
    }
    public async Task<Player> Update(Player player)
    {
        var dbEntry = _context.Update(player);
        await _context.SaveChangesAsync();
        return dbEntry.Entity;
    }
    public async Task Delete(int id)
    {
        var newPlayer = new Player()
        {
            Id = id
        };
        _context.Player.Remove(newPlayer);
        await _context.SaveChangesAsync();
    }
}