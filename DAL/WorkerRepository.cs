using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class WorkerRepository : IRepository<Worker>
{
    private readonly PersonnelDepartmentContext _context = new PersonnelDepartmentContext();
    private readonly DbSet<Worker> _workers;

    public WorkerRepository()
    {
        _workers = _context.Workers;
    }

    public void Add(Worker worker)
    {
        Worker newWorker = (Worker)worker.Clone();
        newWorker.Projects = new List<Project>();
        foreach (var addedProject in worker.Projects)
        {
            var projectId = addedProject.Id;
            newWorker.Projects.Add(_context.Projects.First(project => project.Id == projectId));
        }

        _workers.Add(newWorker);
        _context.SaveChanges();
    }

    public Worker Get(int id)
    {
        return _workers
            .Where(s => s.Id == id)
            .Include(s => s.OccupiedPosition)
            .Include(s => s.AttachedToDivision)
            .Include(s => s.Projects)
            .First();
    }

    public IEnumerable<Worker> GetAll()
    {
        return _workers
            .Include(s => s.OccupiedPosition)
            .Include(s => s.AttachedToDivision)
            .Include(s => s.Projects)
            .ToList();
    }

    public void Remove(Worker worker)
    {
        _workers.Remove(worker);
        _context.SaveChanges();
    }

    public void Update(Worker worker)
    {
        Worker oldWorker = Get(worker.Id);
        oldWorker.Name = worker.Name;
        oldWorker.Surname = worker.Surname;
        oldWorker.SalaryAccount = worker.SalaryAccount;
        oldWorker.Seniority = worker.Seniority;
        oldWorker.OccupiedPositionId = worker.OccupiedPositionId;
        oldWorker.AttachedToDivisionId = worker.AttachedToDivisionId;
        _context.SaveChanges();
    }

    public IEnumerable<Worker> Find(string word)
    {
        return _workers.Where(worker => worker.Name.Contains(word) ||
                                        worker.Surname.Contains(word) ||
                                        worker.SalaryAccount.Contains(word) ||
                                        worker.OccupiedPosition.Name.Contains(word) ||
                                        worker.AttachedToDivision!.Name.Contains(word));
    }

    public IEnumerable<Worker> DeepSearch(Worker lookedWorker)
    {
        return _workers.Where(worker =>
            (worker.Name == lookedWorker.Name || lookedWorker.Name == "") &&
            (worker.Surname == lookedWorker.Surname || lookedWorker.Surname == "") &&
            (worker.SalaryAccount == lookedWorker.SalaryAccount || lookedWorker.SalaryAccount == "") &&
            (worker.Seniority == lookedWorker.Seniority || lookedWorker.Seniority == -1) &&
            (worker.OccupiedPosition.Name == lookedWorker.OccupiedPosition.Name ||
             lookedWorker.OccupiedPosition.Name == "") &&
            (worker.AttachedToDivision!.Name == lookedWorker.AttachedToDivision!.Name ||
             lookedWorker.AttachedToDivision.Name == "")
        );
    }
}