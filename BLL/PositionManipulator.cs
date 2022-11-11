using DAL;
using Entities;

namespace BLL;

public class PositionManipulator : IManipulator<Position>
{
    private IRepository<Position> _repository = new PositionRepository();

    public Position Get(int id)
    {
        return _repository.Get(id);
    }

    public IEnumerable<Position> GetAll()
    {
        return _repository.GetAll();
    }

    
    public void Add(Position position)
    {
        _repository.Add(position);
    }

    public void Remove(Position position)
    {
        _repository.Remove(position);
    }
    
    public void Update(Position position)
    {
        _repository.Update(position);
    }

    public IEnumerable<Position> GetMostAttractive()
    {
       return _repository.GetAll().OrderBy(position => position.Payment/position.WorkingHours).Reverse().Take(5);
    }

    public Worker GetBestWorker(Position position)
    {
        return position.WorkersOnPosition!.MaxBy(worker => worker.Projects.Sum(project => project.ProjectCost)/worker.Seniority)!;
    }

    public IEnumerable<Position> Find(string word)
    {
        return _repository.Find(word);
    }
}