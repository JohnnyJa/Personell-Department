using BLL;
using DAL;
using Entities;

namespace PL;

public class WorkerMenu : IMenu
{
    private readonly WorkerManipulator _manipulator = new WorkerManipulator();

    private int _sortStyleId = 1;

    public void Launch()
    {
        bool isTableOpen = true;
        while (isTableOpen)
        {
            Console.WriteLine(
                "Enter: \n 1 - Add; \n 2 - See more info; \n 3 - Remove; \n 4 - Update; \n 5 - Search worker by key\n 6 - Deep worker search \n 7 - Change sort type \n 0 - quit\n Workers:");

            var workers = GetSorted();
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Add();
                    break;
                case 2:
                    Get();
                    break;
                case 3:
                    Remove(workers);
                    break;
                case 4:
                    Update();
                    break;
                case 5:
                    Find();
                    break;
                case 6:
                    DeepSearch();
                    break;
                case 7:
                    ChooseSortStyle();
                    break;
                case 0:
                    isTableOpen = false;
                    break;
                default:
                    Console.WriteLine("Wrong input\n");
                    break;
            }
        }
    }

    private void Add()
    {
        try
        {
            Console.WriteLine("Enter:");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine()!;
            if (name.Length == 0)
            {
                throw new Exception(message: "Name can't be null");
            }

            Console.WriteLine("Surname: ");
            string surname = Console.ReadLine()!;
            if (name.Length == 0)
            {
                throw new Exception(message: "Surname can't be null");
            }

            Console.WriteLine("Salary account number: ");
            string salaryAccount = Console.ReadLine()!;
            if (name.Length == 0)
            {
                throw new Exception(message: "Salary account number can't be null");
            }

            Console.WriteLine("Seniority: ");
            int seniority = Convert.ToInt32(Console.ReadLine());

            //add using
            IManipulator<Position> positionManipulator = new PositionManipulator();
            foreach (var position in positionManipulator.GetAll())
            {
                Console.WriteLine("{0}, {1}", position.Id, position.Name);
            }

            Console.WriteLine("Position id: ");
            int positionId = Convert.ToInt32(Console.ReadLine());

            //add using
            IManipulator<Division> divisionManipulator = new DivisionManipulator();
            foreach (var division in divisionManipulator.GetAll())
            {
                Console.WriteLine("{0}, {1}", division.Id, division.Name);
            }

            Console.WriteLine("Division id: ");
            int divisionId = Convert.ToInt32(Console.ReadLine());

            IManipulator<Project> projectManipulator = new ProjectManipulator();
            var projects = projectManipulator.GetAll().ToList();

            foreach (var project in projects)
            {
                Console.WriteLine("{0}, {1}", project.Id, project.Name);
            }

            var addedProjects = new List<Project>();
            bool isLastProject = false;

            while (!isLastProject)
            {
                int projectId = Convert.ToInt32(Console.ReadLine());
                switch (projectId)
                {
                    case 0:
                        isLastProject = true;
                        break;
                    default:
                        addedProjects.Add(new Project()
                        {
                            Id = projectId
                        });
                        break;
                }
            }

            Worker worker = new Worker()
            {
                Name = name,
                Surname = surname,
                SalaryAccount = salaryAccount,
                Seniority = seniority,
                AttachedToDivisionId = divisionId,
                OccupiedPositionId = positionId,
                Projects = addedProjects
            };
            _manipulator.Add(worker);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    private void Remove(IEnumerable<Worker> workers)
    {
        try
        {
            Console.WriteLine("Enter worker number to remove");
            int id = Convert.ToInt32(Console.ReadLine());
            _manipulator.Remove(workers.First(s => s.Id == id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void Update()
    {
        try
        {
            Console.WriteLine("Enter worker number to update");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new Name:");
            string name = Console.ReadLine()!;
            if (name.Length == 0)
            {
                throw new Exception(message: "Name can't be null");
            }

            Console.WriteLine("Enter new Surname: ");

            string surname = Console.ReadLine()!;
            if (surname.Length == 0)
            {
                throw new Exception(message: "Surname can't be null");
            }

            Console.WriteLine("Enter new Salary account number: ");

            string salaryAccount = Console.ReadLine()!;
            if (salaryAccount.Length == 0)
            {
                throw new Exception(message: "Salary account number can't be null");
            }

            Console.WriteLine("Enter new seniority (in month): ");

            int seniority = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new Position id");

            int positionId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new Division id");

            int divisionId = Convert.ToInt32(Console.ReadLine());

            Worker worker = new Worker()
            {
                Id = id,
                Name = name,
                Surname = surname,
                SalaryAccount = salaryAccount,
                Seniority = seniority,
                AttachedToDivisionId = divisionId,
                OccupiedPositionId = positionId
            };
            _manipulator.Update(worker);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Get()
    {
        try
        {
            Console.WriteLine("Enter worker number: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Worker worker = _manipulator.Get(id);
            Console.WriteLine(worker.Name);
            Console.WriteLine(worker.Surname);
            Console.WriteLine(worker.SalaryAccount);
            Console.WriteLine(worker.Seniority);
            Console.WriteLine(worker.OccupiedPosition.Name);
            Console.WriteLine(worker.AttachedToDivision!.Name);
            Console.WriteLine("Enter: \n 1 - See workers project \n 0 - quit");
            int flag = Convert.ToInt32(Console.ReadLine());
            switch (flag)
            {
                case 1:
                    IEnumerable<Project> projects = worker.Projects;
                    foreach (var project in projects)
                    {
                        Console.WriteLine(project.Name);
                    }

                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void ChooseSortStyle()
    {
        try
        {
            Console.WriteLine(
                "Enter: \n 1 - Sort by number; \n 2 - Sort by name; \n 3 - Sort by surname; \n 4 - Sort by payment");

            _sortStyleId = Convert.ToInt32(Console.ReadLine());
            if (_sortStyleId <= 0 || _sortStyleId > 4)
            {
                throw new Exception(message: "Wrong input");
            }
        }
        catch (Exception e)
        {
            _sortStyleId = 1;
            Console.WriteLine(e.Message);
        }
    }

    private IEnumerable<Worker> GetSorted()
    {
        IEnumerable<Worker> workers;
        switch (_sortStyleId)
        {
            case 1:
                workers = _manipulator.GetAll().ToList();
                break;
            case 2:
                workers = _manipulator.SortByName().ToList();
                break;
            case 3:
                workers = _manipulator.SortBySurname().ToList();
                break;
            case 4:
                workers = _manipulator.SortByPayment().ToList();
                break;
            default:
                workers = _manipulator.GetAll().ToList();
                break;
        }

        foreach (var worker in workers)
        {
            Console.WriteLine("{0}, {1}, {2}, {3}", worker.Id, worker.Name, worker.Surname,
                worker.OccupiedPosition.Name);
        }

        return workers;
    }

    private void Find()
    {
        try
        {
            Console.WriteLine("Enter key-word: ");
            List<Worker> workers = _manipulator.Find(Console.ReadLine()!).ToList();

            if (!workers.Any())
            {
                throw new Exception(message: "Workers doesn't found");
            }

            foreach (var worker in workers)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", worker.Id, worker.Name, worker.Surname,
                    worker.OccupiedPosition.Name);
            }


            Console.WriteLine("Enter: \n 1 - See more info \n 0 - back ");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Get();
                    break;
                case 0:
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void DeepSearch()
    {
        try
        {
            Console.WriteLine("Enter Name (or press enter if you don`t remember)");
            string name = Console.ReadLine()!;

            Console.WriteLine("Enter Surname (or press enter if you don`t remember)");

            string surname = Console.ReadLine()!;

            Console.WriteLine("Enter Salary account number (or press enter if you don`t remember)");
            string salaryAccount = Console.ReadLine()!;

            Console.WriteLine("Enter Seniority (or press enter if you don`t remember)");
            var strSeniority = Console.ReadLine();
            int seniority;
            if (strSeniority == "")
            {
                seniority = -1;
            }
            else
            {
                seniority = Convert.ToInt32(strSeniority);
            }

            Console.WriteLine("Enter Position name (or press enter if you don`t remember)");
            string position = Console.ReadLine()!;

            Console.WriteLine("Enter Division name (or press enter if you don`t remember)");
            string division = Console.ReadLine()!;

            Worker lookedWorker = new Worker()
            {
                Name = name,
                Surname = surname,
                SalaryAccount = salaryAccount,
                Seniority = seniority,
                AttachedToDivision = new Division()
                {
                    Name = division
                },
                OccupiedPosition = new Position()
                {
                    Name = position
                },
            };

            List<Worker> workers = _manipulator.DeepSearch(lookedWorker).ToList();
            
            if (!workers.Any())
            {
                throw new Exception(message: "Workers doesn't found");
            }
            
            foreach (var worker in workers)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", worker.Id, worker.Name, worker.Surname,
                    worker.OccupiedPosition.Name);
            }

            Console.WriteLine("Enter: \n 1 - See more info \n 0 - back ");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Get();
                    break;
                case 0:
                    break;
                default:
                    throw new Exception(message: "Wrong input");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}