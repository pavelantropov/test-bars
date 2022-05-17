using Server.Models;
using Server.Repositories;

namespace Server.Services;

public class ContractService : IItemService<Contract>
{
    private readonly IRepository<Contract> _repo;

    public ContractService(IRepository<Contract> repo)
    {
        _repo = repo;
    }

    public Contract? Get(int id) =>
        _repo.Get(id);

    public IEnumerable<Contract> GetAll() =>
        _repo.Items;

    public void Add(Contract item) => 
        _repo.Add(item);

    public void Update(Contract updatedItem, int id) => 
        _repo.Update(updatedItem, id);

    public void Delete(int id) => 
        _repo.Remove(id);
}