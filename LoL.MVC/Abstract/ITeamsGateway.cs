using LoL.MVC.Domain;

namespace LoL.MVC.Abstract;

public interface ITeamsGateway
{
    public Task<IEnumerable<Team>> GetAll();

    Task<Team?> GetById(int id);

    Task<Team> Create(Team team);
    Task<Team> Update(Team team);

    Task Delete(int id);
}