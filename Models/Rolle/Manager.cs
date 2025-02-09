using NuGet.DependencyResolver;

namespace SP.Models.Rolle
{
    public class Manager
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public ICollection<Lehrer> Lehrers { get; set; } = new List<Lehrer>();
        // Навигационные свойства
        public string ApplicationUserId { get; set; } = null!;
        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
