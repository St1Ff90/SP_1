namespace SP.Models.Rolle
{
    public class User: ApplicationUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;

        // Поле для определения роли пользователя
        public string Role { get; set; } = string.Empty;
    }
}
