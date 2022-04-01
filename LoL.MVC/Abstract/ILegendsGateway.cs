namespace LoL.MVC.Abstract;

using Domain;

public interface ILegendsGateway
{
    public Task<IEnumerable<Legend>> GetAll();

    Task<Legend?> GetById(int id);

    Task<Legend> Create(Legend legend);
    Task<Legend> Update(Legend legend);

    Task Delete(int id);
}