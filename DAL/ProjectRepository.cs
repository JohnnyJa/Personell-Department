using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ProjectRepository : IRepository<Project>
{
    private readonly PersonnelDepartmentContext _context = new PersonnelDepartmentContext();
    private readonly DbSet<Project> _projects;

    public ProjectRepository()
    {
        _projects = _context.Projects;
    }

    public void Add(Project project)
    {
        _projects.Add(project);
        _context.SaveChanges();

    }
    public void Update(Project project)
    {
        
    }

    public Project Get(int id)
    {
        return _projects
            .First(s => s.Id == id);
    }

    public IEnumerable<Project> GetAll()
    {
        return _projects
            .ToList();
    }

    public void Remove(Project project)
    {
        _projects.Remove(project);
        _context.SaveChanges();

    }
    
    public IEnumerable<Project> Find(string word)
    {
        return _projects.Where(project => project.Name.Contains(word));
    }
}