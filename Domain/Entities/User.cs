namespace Domain.Entities;

public class User : BaseEntity
{
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Password { get; set; }

    public ICollection<Role> Roles { get; set; } = new HashSet<Role>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
    public ICollection<RoleUser> RolesUsers { get; set; }
}
