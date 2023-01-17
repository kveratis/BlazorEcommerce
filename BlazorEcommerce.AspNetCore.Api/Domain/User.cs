namespace BlazorEcommerce.AspNetCore.Api.Domain
{
    public sealed class User
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
