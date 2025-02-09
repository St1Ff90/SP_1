namespace SP.Models.Rolle
{
    public class Lehrer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        // Связь с расписанием
        public ICollection<Unterricht> Lessons { get; set; } = new List<Unterricht>();

        // Навигационные свойства
        public string ApplicationUserId { get; set; } = null!;
        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
