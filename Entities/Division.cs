namespace Entities
{
    public sealed class Division : ICloneable
    {
        public int Id { get; init; }
        public string Name { get; set; } = null!;

        public List<Worker> AttachedWorkers { get; private init; } = null!;

        public object Clone()
        {
            return new Division()
            {
                Id = this.Id,
                Name = this.Name,
                AttachedWorkers = ((Worker[])this.AttachedWorkers.ToArray().Clone()).ToList()
            };
        }
    }
}