using BLL;
using DAL;
using Entities;

namespace PL;

public class ProjectMenu : IMenu
{
    private readonly ProjectManipulator _manipulator = new ProjectManipulator();

    public void Launch()
    {
        Console.WriteLine(
            "Enter: \n 1 - Add; \n 2 - See more info; \n 3 - Remove; \n 4 - Update; \n 5 - Find \n 0 - quit");

        bool isTableOpen = true;
        while (isTableOpen)
        {
            var projects = GetSorted();
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Add();
                    break;
                case 2:
                    Get();
                    break;
                case 3:
                    Remove(projects);
                    break;
                case 4:
                    Update();
                    break;
                case 5:
                    Find();
                    break;
                case 0:
                    isTableOpen = false;
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    break;
            }
        }
    }

    private IEnumerable<Project> GetSorted()
    {
        IEnumerable<Project> projects = _manipulator.GetAll().ToList();
        foreach (var project in projects)
        {
            Console.WriteLine("{0}, {1}", project.Id, project.Name);
        }

        return projects;
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

            Console.WriteLine("Project Cost: ");
            int projectCost = Convert.ToInt32(Console.ReadLine());

            Project project = new Project
            {
                Name = name,
                ProjectCost = projectCost
            };

            _manipulator.Add(project);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void Remove(IEnumerable<Project> projects)
    {
        try
        {
            Console.WriteLine("Enter project number to remove");

            int id = Convert.ToInt32(Console.ReadLine());
            _manipulator.Remove(projects.First(s => s.Id == id));
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
            Console.WriteLine("Enter project number to update");

            int id = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Name: ");
            string name = Console.ReadLine()!;
            
            if (name.Length == 0)
            {
                throw new Exception(message: "Name can't be empty");
            }
            
            Console.WriteLine("Project Cost: ");
            int projectCost = Convert.ToInt32(Console.ReadLine());

            Project project = new Project
            {
                Id = id,
                Name = name,
                ProjectCost = projectCost
            };

            _manipulator.Update(project);
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
            Console.WriteLine("Enter project number: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Project project = _manipulator.Get(id);
            Console.WriteLine(project.Name);
            Console.WriteLine(project.ProjectCost);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
       
    }

    private void Find()
    {
        try
        {
            Console.WriteLine("Enter key-word: ");
            List<Project> projects = _manipulator.Find(Console.ReadLine()!).ToList();
            
            if (!projects.Any())
            {
                throw new Exception(message: "Workers doesn't found");
            }
            
            foreach (var project in projects)
            {
                Console.WriteLine("{0}, {1}", project.Id, project.Name);
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
}