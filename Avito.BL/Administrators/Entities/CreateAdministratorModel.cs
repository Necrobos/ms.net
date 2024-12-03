namespace Avito.BL.Administrators.Entities;

public class CreateAdministratorModel
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; } 
    public int LevelAccess { get; set; }
}