using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class DivisionRepository : IRepository<Division>
{
    private readonly PersonnelDepartmentContext _context = new PersonnelDepartmentContext();
    private readonly DbSet<Division> _divisions;

    public DivisionRepository()
    {
        _divisions = _context.Divisions;
    }

    public void Add(Division division)
    {
        _divisions.Add(division);
        _context.SaveChanges();
    }

    public Division Get(int id)
    {
        return _divisions
            .Where(s => s.Id == id)
            .Include(s => s.AttachedWorkers)
                .ThenInclude(t => t.OccupiedPosition)
            .Include(s => s.AttachedWorkers)
                .ThenInclude(t => t.Projects)
            .First();
    }

    public IEnumerable<Division> GetAll()
    {
        return _divisions
            .Include(s => s.AttachedWorkers)
                .ThenInclude(t => t.OccupiedPosition)
            .Include(s => s.AttachedWorkers)
                .ThenInclude(t => t.Projects)
            .ToList();
    }

    public void Remove(Division division)
    {
        _divisions.Remove(division);
        _context.SaveChanges();

    }
    public void Update(Division division)
    {
        Division oldDivision = Get(division.Id);
        oldDivision.Name = division.Name;
        _context.SaveChanges();
    }

    public IEnumerable<Division> Find(string word)
    {
        return _divisions.Where(division => division.Name.Contains(word));
    }
    
}