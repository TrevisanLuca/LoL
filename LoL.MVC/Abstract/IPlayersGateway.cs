namespace LoL.MVC.Abstract;

using Domain;

public interface IPlayersGateway
{
    public Task<IEnumerable<Player>> GetAll();

    Task<Player?> GetById(int id);

    Task<Player> Create(Player player);
    Task<Player> Update(Player player);

    Task Delete(int id);
    Task<IEnumerable<Player>> GetFree(int? id);
}