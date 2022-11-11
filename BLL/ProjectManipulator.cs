using DAL;
using Entities;

namespace BLL;

public class ProjectManipulator : IManipulator<Project>
{
    private readonly IRepository<Project> _repository = new ProjectRepository();

    public Project Get(int id)
    {
        return _repository.Get(id);
    }
    public IEnumerable<Project> GetAll()
    {
        return _repository.GetAll();
    }

    public void Add(Project worker)
    {
        _repository.Add(worker);
    }

    public void Remove(Project worker)
    {
        _repository.Remove(worker);
    }
    
    public void Update(Project worker)
    {
        _repository.Update(worker);
    }
    
    public IEnumerable<Project> Find(string word)
    {
        return _repository.Find(word);
    }
}