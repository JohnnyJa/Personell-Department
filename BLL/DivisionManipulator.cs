using DAL;
using Entities;

namespace BLL;

public class DivisionManipulator : IManipulator<Division>
{
    private readonly IRepository<Division> _repository = new DivisionRepository();

    public Division Get(int id)
    {
        return _repository.Get(id);
    }
    public IEnumerable<Division> GetAll()
    {
        return _repository.GetAll();
    }

    public void Add(Division division)
    {
        _repository.Add(division);
    }

    public void Remove(Division division)
    {
        _repository.Remove(division);
    }
    
    public void Update(Division division)
    {
        _repository.Update(division);
    }

    public IEnumerable<Worker> GetWorkers(Division division)
    {
       return division.AttachedWorkers.ToList();
    }
    public IEnumerable<Worker> GetWorkersSortedByPosition(Division division)
    {
        return division.AttachedWorkers.OrderBy(worker => worker.OccupiedPosition.Name);
    }
    public IEnumerable<Worker> GetWorkersSortedBySummaryProjectCost(Division division)
    {
        return division.AttachedWorkers.OrderBy(worker => worker.Projects.Sum(t => t.ProjectCost)).Reverse();
    }
    public IEnumerable<Division> Find(string word)
    {
        return _repository.Find(word);
    }
}