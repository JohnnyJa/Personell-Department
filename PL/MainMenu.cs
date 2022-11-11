using BLL;
using DAL;
using Entities;

namespace PL;

public class MainMenu : IMenu
{
    public void Launch()
    {
        ChooseTable();
    }

    private void ChooseTable()
    {
        Console.WriteLine("Enter: \n 1 - Worker Table; \n 2 - Division Table; \n 3 - Position Table; \n 4 - Project Table; \n 5 - Search in all tables \n");
        IMenu menu;
        switch (Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
                menu = new WorkerMenu();
                menu.Launch();
                break;
            case 2:
                menu = new DivisionMenu();
                menu.Launch();
                break;
            case 3:
                menu = new PositionMenu();
                menu.Launch();
                break;
            case 4:
                menu = new ProjectMenu();
                menu.Launch();
                break;
            case 5:
                Find();
                break;
            default:
                menu = new WorkerMenu();
                break;
        }
    }

    private void Find()
    {
        Console.WriteLine("Enter key-word: ");
        string key = Console.ReadLine();
        
        WorkerManipulator workerManipulator = new WorkerManipulator();
        IEnumerable<Worker> workers = workerManipulator.Find(key);
        
        Console.WriteLine("Result of search in worker");

        foreach (var worker in workers)
        {
            Console.WriteLine("{0}, {1}, {2}",worker.Id, worker.Name, worker.Surname);
        }
        Console.WriteLine("Enter: \n 1 - See more info \n 0 - continue search ");

        switch (Convert.ToInt32( Console.ReadLine()))
        {
            case 1:
                WorkerMenu menu = new WorkerMenu();
                menu.Get();
                break;
            case 0:
                break;
        }
        
        DivisionManipulator divisionManipulator = new DivisionManipulator();
        IEnumerable<Division> divisions = divisionManipulator.Find(key);
        
        Console.WriteLine("Result of search in division");

        foreach (var division in divisions)
        {
            Console.WriteLine("{0}, {1}",division.Id, division.Name);
        }
        Console.WriteLine("Enter: \n 1 - See more info \n 0 - continue search ");

        switch (Convert.ToInt32( Console.ReadLine()))
        {
            case 1:
                DivisionMenu menu = new DivisionMenu();
                menu.Get();
                break;
            case 0:
                break;
        }
        
        PositionManipulator positionManipulator = new PositionManipulator();
        IEnumerable<Position> positions = positionManipulator.Find(key);
        
        Console.WriteLine("Result of search in position");

        foreach (var position in positions)
        {
            Console.WriteLine("{0}, {1}",position.Id, position.Name);
        }
        Console.WriteLine("Enter: \n 1 - See more info \n 0 - continue search ");

        switch (Convert.ToInt32( Console.ReadLine()))
        {
            case 1:
                PositionMenu menu = new PositionMenu();
                menu.Get();
                break;
            case 0:
                break;
        }
        
        ProjectManipulator projectManipulator = new ProjectManipulator();
        IEnumerable<Project> projects = projectManipulator.Find(key);
        
        Console.WriteLine("Result of search in project");

        foreach (var project in projects)
        {
            Console.WriteLine("{0}, {1}",project.Id, project.Name);
        }
        Console.WriteLine("Enter: \n 1 - See more info \n 0 - finish");

        switch (Convert.ToInt32( Console.ReadLine()))
        {
            case 1:
                ProjectMenu menu = new ProjectMenu();
                menu.Get();
                break;
            case 0:
                break;
        }
    }
    
    
}