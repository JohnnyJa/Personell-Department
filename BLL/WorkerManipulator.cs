using DAL;
using Entities;

namespace BLL;

public class WorkerManipulator : IManipulator<Worker>
{
    private readonly WorkerRepository _repository = new WorkerRepository();

    public Worker Get(int id)
    {
        return _repository.Get(id);
    }
    public IEnumerable<Worker> GetAll()
    {
        return _repository.GetAll();
    }

    public void Add(Worker worker)
    {
        _repository.Add(worker);
    }

    public void Remove(Worker worker)
    {
        _repository.Remove(worker);
    }
    
    public void Update(Worker worker)
    {
        _repository.Update(worker);
    }

    public IEnumerable<Worker> SortByName()
    {
        return _repository.GetAll().OrderBy(worker => worker.Name);
    }

    public IEnumerable<Worker> SortBySurname()
    {
        return _repository.GetAll().OrderBy(worker => worker.Surname);
    }

    public IEnumerable<Worker> SortByPayment()
    {
        return _repository.GetAll().OrderBy(worker => worker.OccupiedPosition.Payment);
    }

    public IEnumerable<Worker> Find(string word)
    {
       return _repository.Find(word);
    }

    public IEnumerable<Worker> DeepSearch(Worker lookedWorker)
    {
        return _repository.DeepSearch(lookedWorker);
    }
}