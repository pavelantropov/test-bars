using Server.Models;

namespace Server.Services;

public interface IItemService<T>
{
    Contract? Get(int id);
    IEnumerable<T> GetAll();

    void Add(T item);
    void Update(T updatedItem, int id);
    void Delete(int id);
}