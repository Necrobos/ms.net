namespace Avito.DataAccess.Entities;

public class Seller : User
{
    public int PassSeriesAndNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<ItemForSelling> Items { get; set; }
}