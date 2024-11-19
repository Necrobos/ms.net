namespace Avito.DataAccess.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedOnTime { get; set; }
    public DateTime ModifiedOnTime { get; set; }
}