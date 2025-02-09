using NuGet.DependencyResolver;
using SP.Models.Unterrichten;

namespace SP.Models
{
    /// <summary>
/// Описывает занятия которые будут или были проведены у учителя
/// </summary>
    public class Unterricht
    {
        public int Id { get; set; }
        public Uebung Übungen { get; set; }
        public bool Status { get; set; } = false; 
        // Связь с учителями и учениками
        public int? TeacherId { get; set; }
        public Rolle.Lehrer? Lehrer { get; set; }

        public ICollection<StudentUnterricht> StudentLessons { get; set; } = new List<StudentUnterricht>();
    }
}
