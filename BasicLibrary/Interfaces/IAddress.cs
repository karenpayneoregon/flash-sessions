namespace BasicLibrary.Interfaces;
public interface IAddress
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
}