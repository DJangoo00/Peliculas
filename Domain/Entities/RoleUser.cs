namespace Domain.Entities;

public class RoleUser
{
    public int IdUserFk { get; set; }
    public User User { get; set; }
    public int IdRoleFk { get; set; }
    public Role Role { get; set; }
}
