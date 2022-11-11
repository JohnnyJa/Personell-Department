
namespace Entities
{
    public class Position : ICloneable
    {
        public int Id { get; init; }
        public string Name { get; set; } = null!;
        public int Payment { get; set; }
        public int WorkingHours { get; set; }
        
        public List<Worker>? WorkersOnPosition { get; private init; }
        public object Clone()
        {
            return new Position
            {
                Id = Id,
                Name = Name,
                Payment = Payment,
                WorkingHours = WorkingHours,
                WorkersOnPosition = ((Worker[])this.WorkersOnPosition!.ToArray().Clone()).ToList()
            };

        }
    }
}