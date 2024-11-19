namespace Avito.DataAccess.Entities;

public class User : BaseEntity
{
    public string UserFIO { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; } 
}