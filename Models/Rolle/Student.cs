namespace SP.Models.Rolle
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Level Level { get; set; }
        // Связь с уроками и отчетами
        public ICollection<UnterrichtReport> LessonReports { get; set; } = new List<UnterrichtReport>();

        // Навигационные свойства
        public string ApplicationUserId { get; set; } = null!;
        public ApplicationUser ApplicationUser { get; set; } = null!;

    }
}
