using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SP.Models;
using SP.Models.Rolle;
using SP.Models.Unterrichten;

namespace SP.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        const string adminEmail = "admin@admin.ua";

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ApplicationUser user = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = adminEmail,
                NormalizedUserName = adminEmail.ToUpper(),
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpper(),
                Vorname = "Admin",
                Type = UserType.Admin,
            };

            user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, "12345trewq");

            builder.Entity<ApplicationUser>().HasData(user);

            builder.Entity<IdentityRole>().HasData(
               new IdentityRole
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Admin",
                   NormalizedName = "ADMIN"
               },
               new IdentityRole
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Manager",
                   NormalizedName = "MANAGER"
               },
               new IdentityRole
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Student",
                   NormalizedName = "STUDENT"
               },
               new IdentityRole
               {
                   Id = Guid.NewGuid().ToString(),
                   Name = "Lehrer",
                   NormalizedName = "LEHRER"
               }
            );
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Thema> Themens { get; set; }

        public DbSet<Unterthema> Unterthemas { get; set; }

        public DbSet<Uebung> Uebungens { get; set; }

    }
}
