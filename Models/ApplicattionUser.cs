using Microsoft.AspNetCore.Identity;
using NuGet.DependencyResolver;
using SP.Models.Rolle;
using System.ComponentModel.DataAnnotations;

namespace SP.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Vorname")]
        public string Vorname { get; set; } = string.Empty;

        public string? Nachname { get; set; } 
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; } 

        public UserType Type { get; set; } = UserType.Student;

        public ICollection<Lehrer>? Teachers { get; set; }
        public ICollection<Student>? Students { get; set; }
    }

    public enum UserType
    {
        Student,
        Lehrer, 
        Manager,
        Admin
    }
}
