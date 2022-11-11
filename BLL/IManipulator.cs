namespace BLL;

public interface IManipulator<T>
{
    T Get(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Remove(T entity);

    void Update(T entity);
}