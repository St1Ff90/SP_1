using SP.Models.Rolle;

namespace SP.Models
{
    /// <summary>
    /// Отображаются уроки которые были проведены для стуудента
    /// </summary>
    public class UnterrichtReport
    {
        public int Id { get; set; }
        public DateTime CompletedAt { get; set; }
        public string Notes { get; set; } = null!;

        // Навигационные свойства
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public int UnterrichtId { get; set; }
        public Unterricht Unterricht { get; set; } = null!;
    }
}
