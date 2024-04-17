namespace BasicLibrary.Models;

public interface IBaseProduct
{
    public int Id { get; }
}
public interface IProduct
{
    int ProductID { get; set; }
    string ProductName { get; set; }
    int? SupplierID { get; set; }
    int? CategoryID { get; set; }
}

public class Product : IBaseProduct, IProduct
{
    public int Id => ProductID;
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int? SupplierID { get; set; }
    public int? CategoryID { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal? UnitPrice { get; set; }
    public int? UnitsInStock { get; set; }
    public int? UnitsOnOrder { get; set; }
    public int? ReorderLevel { get; set; }
    public bool Discontinued { get; set; }
    public DateTime? DiscontinuedDate { get; set; }
}
