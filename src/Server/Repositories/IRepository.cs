namespace Server.Repositories;

public interface IRepository<T>
{
    List<T> Items { get; }

    T? Get(int id);

    void Add(T item);
    void Update(T updatedItem, int id);
    void Remove(int id);
}