using BLL;
using DAL;
using Entities;

namespace PL;

public class DivisionMenu : IMenu
{
    private readonly DivisionManipulator _manipulator = new DivisionManipulator();

    public void Launch()
    {
        bool isTableOpen = true;
        while (isTableOpen)
        {
            Console.WriteLine("Enter: \n 1 - Add; \n 2 - See more info; \n 3 - Remove; \n 4 - Update; \n 0 - quit");

            var divisions = GetSorted();
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Add();
                    break;
                case 2:
                    Get();
                    break;
                case 3:
                    Remove(divisions);
                    break;
                case 4:
                    Update();
                    break;
                case 0:
                    isTableOpen = false;
                    break;
                default:
                    Console.WriteLine("Wrong input");
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
                throw new Exception(message: "Name can't be empty");
            }

            Division division = new Division()
            {
                Name = name,
            };

            _manipulator.Add(division);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void Remove(IEnumerable<Division> divisions)
    {
        try
        {
            Console.WriteLine("Enter division number to remove");
            int id = Convert.ToInt32(Console.ReadLine());
            _manipulator.Remove(divisions.First(s => s.Id == id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private IEnumerable<Division> GetSorted()
    {
        IEnumerable<Division> divisions = _manipulator.GetAll().ToList();

        foreach (var division in divisions)
        {
            Console.WriteLine("{0}, {1}", division.Id, division.Name);
        }

        return divisions;
    }

    private void Update()
    {
        try
        {
            Console.WriteLine("Enter positions number to update");

            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("New name: ");

            string name = Console.ReadLine()!;

            if (name.Length == 0)
            {
                throw new Exception(message: "Name can't be empty");
            }

            Division division = new Division()
            {
                Id = id,
                Name = name
            };
            _manipulator.Update(division);
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
            Console.WriteLine("Enter division number: ");

            int id = Convert.ToInt32(Console.ReadLine());
            Division division = _manipulator.Get(id);

            Console.WriteLine(division.Name);
            
            bool isWorkEnded = false;
            while (!isWorkEnded)
            {
                Console.WriteLine(
                    "Enter:\n 1 - See workers sorted by numbers \n 2 - Sorted by position \n 3 - Sorted by summary project cost \n 0 - quit");

                IEnumerable<Worker> workers;
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        workers = _manipulator.GetWorkers(division);
                        foreach (var worker in workers)
                        {
                            Console.WriteLine("{0}, {1}, {2}", worker.Id, worker.Surname, worker.Name);
                        }

                        break;

                    case 2:
                        workers = _manipulator.GetWorkersSortedByPosition(division);
                        foreach (var worker in workers)
                        {
                            Console.WriteLine("{0}, {1}, {2}, {3}", worker.Id, worker.Surname, worker.Name,
                                worker.OccupiedPosition.Name);
                        }

                        break;
                    case 3:
                        workers = _manipulator.GetWorkersSortedBySummaryProjectCost(division);
                        foreach (var worker in workers)
                        {
                            Console.WriteLine("{0}, {1}, {2}, {3}", worker.Id, worker.Surname, worker.Name,
                                worker.Projects.Sum(project => project.ProjectCost));
                        }

                        break;
                    case 0:
                        isWorkEnded = true;
                        break;
                    default:
                        Console.WriteLine("Wrong Input!");
                        break;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}