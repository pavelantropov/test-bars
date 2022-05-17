namespace Server.Repositories;

public interface IRepository<T>
{
    List<T> Items { get; }

    T? Get(int id);
    IEnumerable<T> Find(Func<T, bool> predicate);

    void Add(T item);
    void Remove(T item);
    void Update(T updatedItem, int id);
}