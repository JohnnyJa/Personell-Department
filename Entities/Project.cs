namespace Entities
{
    public class Project
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public int ProjectCost { get; init; }

        public List<Worker> Workers { get; set; } = null!;
    }
}