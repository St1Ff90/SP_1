namespace SP.Models
{
    public class UnterrichtPlan
    {
        public int Id { get; set; }
        public Level Level { get; set; }
        public string Description { get; set; } = null!;

        // Связь с уроками
        public ICollection<Unterricht> Lessons { get; set; } = new List<Unterricht>();
    }
}
