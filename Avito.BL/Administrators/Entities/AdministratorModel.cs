namespace Avito.BL.Administrators.Entities;

public class AdministratorModel
{
    public int Id { get; set; }
    public DateTime CreatedOnTime { get; set; }
    public DateTime ModifiedOnTime { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    
    public int LevelAccess { get; set; }
}