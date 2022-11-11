
namespace Entities
{
    public sealed class Worker : ICloneable
    {
        
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string SalaryAccount { get; set; } = null!;
        public int Seniority { get; set; }
        
        public int OccupiedPositionId { get; set; }

        public Position OccupiedPosition { get; init; } = null!;

        public int? AttachedToDivisionId { get; set; }
        public Division? AttachedToDivision { get; init; }
        public List<Project> Projects { get; set; } = new List<Project>();

        public object Clone()
        {
            return new Worker()
            {
                Id = this.Id,
                Name = this.Name,
                Surname = this.Surname,
                SalaryAccount = this.SalaryAccount,
                Seniority = this.Seniority,
                AttachedToDivisionId = this.AttachedToDivisionId,
                OccupiedPositionId = this.OccupiedPositionId,
                Projects = ((Project[])this.Projects.ToArray().Clone()).ToList()
            };
        }
    }
}