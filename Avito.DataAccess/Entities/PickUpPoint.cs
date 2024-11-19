namespace Avito.DataAccess.Entities;

public class PickUpPoint :BaseEntity
{
    public string PickUpPointName { get; set; }
    public string Address { get; set; }
    public string ServiceName { get; set; }
    public List<ItemForSelling> Items { get; set; }
}