namespace Avito.DataAccess.Entities;

public class ItemForSelling : BaseEntity
{
    public string Description {get; set;}
    public int Price {get; set;}
    public DateTime DateOfExposing {get; set;}
    public int PickUpPointId {get; set;}
    public PickUpPoint PickUpPoint {get; set;}
    public List<Seller> Sellers {get; set;}
}