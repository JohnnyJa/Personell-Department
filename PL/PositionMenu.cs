using BLL;
using DAL;
using Entities;

namespace PL;

public class PositionMenu : IMenu
{
    private readonly PositionManipulator _manipulator = new PositionManipulator();

    public void Launch()
    {
        Console.WriteLine(
            "Enter: \n 1 - Add; \n 2 - See more info; \n 3 - Remove; \n 4 - Update; \n 5 - Get most attractive position \n 0 - quit");

        bool isTableOpen = true;
        while (isTableOpen)
        {
            var positions = GetSorted();
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Add();
                    break;
                case 2:
                    Get();
                    break;
                case 3:
                    Remove(positions);
                    break;
                case 4:
                    Update();
                    break;
                case 5:
                    GetMostAttractive();
                    break;
                case 0:
                    isTableOpen = false;
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

            Console.WriteLine("Payment: ");
            int payment = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Working hours: ");
            int workingHours = Convert.ToInt32(Console.ReadLine());

            Position worker = new Position()
            {
                Name = name,
                Payment = payment,
                WorkingHours = workingHours
            };

            _manipulator.Add(worker);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void Remove(IEnumerable<Position> positions)
    {
        try
        {
            Console.WriteLine("Enter position number to remove");

            int id = Convert.ToInt32(Console.ReadLine());
            _manipulator.Remove(positions.First(s => s.Id == id));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private IEnumerable<Position> GetSorted()
    {
        IEnumerable<Position> positions = _manipulator.GetAll().ToList();

        foreach (var position in positions)
        {
            Console.WriteLine("{0}, {1}", position.Id, position.Name);
        }

        return positions;
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
            
            Console.WriteLine("New payment: ");
            int payment = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("New working hours: ");
            int workingHours = Convert.ToInt32(Console.ReadLine());

            Position position = new Position()
            {
                Id = id,
                Name = name,
                Payment = payment, 
                WorkingHours = workingHours
            };
            _manipulator.Update(position);
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
            Console.WriteLine("Enter positions number: ");

            int id = Convert.ToInt32(Console.ReadLine());
            Position position = _manipulator.Get(id);

            Console.WriteLine("{0}, {1}, {2}", position.Name, position.Payment, position.WorkingHours);
            Console.WriteLine("Enter:\n 1 - Get best worker; \n 0 - quit; ");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    GetBestWorker(position);
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

    private void GetMostAttractive()
    {
        Console.WriteLine("Most attractive position are:\n");
        foreach (var position in _manipulator.GetMostAttractive())
        {
            Console.WriteLine(position.Name);
        }
    }

    private void GetBestWorker(Position position)
    {
        Worker bestWorker = _manipulator.GetBestWorker(position);
        Console.WriteLine("{0}, {1}", bestWorker.Name,
            bestWorker.Projects.Sum(project => project.ProjectCost) / bestWorker.Seniority);
    }
}