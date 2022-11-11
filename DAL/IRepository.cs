namespace DAL;

public interface IRepository<T>
{

    T Get(int id);
    void Add(T entity);
    void Remove(T entity);
    void Update(T entity);
    IEnumerable<T> GetAll();

    IEnumerable<T> Find(string word);
}