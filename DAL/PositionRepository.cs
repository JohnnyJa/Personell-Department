using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class PositionRepository : IRepository<Position>
{
    private readonly PersonnelDepartmentContext _context = new PersonnelDepartmentContext();
    private readonly DbSet<Position> _positions;

    public PositionRepository()
    {
        _positions = _context.Positions;
    }

    public void Update(Position position)
    {
        Position oldPosition = Get(position.Id);
        oldPosition.Name = position.Name;
        oldPosition.Payment = position.Payment;
        oldPosition.WorkingHours = position.WorkingHours;
        _context.SaveChanges();
    }

    public void Add(Position position)
    {
        _positions.Add(position);
        _context.SaveChanges();
    }

    public Position Get(int id)
    {
        return _positions
            .Where(s => s.Id == id)
            .Include(s => s.WorkersOnPosition)!
            .ThenInclude(g => g.Projects)
            .First();
    }

    public IEnumerable<Position> GetAll()
    {
        return _positions
            .Include(s => s.WorkersOnPosition)!
            .ThenInclude(g => g.Projects)
            .ToList();
    }

    public void Remove(Position position)
    {
        _positions.Remove(position);
        _context.SaveChanges();
    }

    public IEnumerable<Position> Find(string word)
    {
        return _positions.Where(position => position.Name.Contains(word));
    }
}