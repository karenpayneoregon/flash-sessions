#nullable disable
using ConditionalBreakpointsSample.Models;

namespace ConditionalBreakpointsSample.Classes;

public class DataOperations
{
    private static readonly Lazy<DataOperations> Lazy = new(() => new DataOperations());
    public static DataOperations Instance => Lazy.Value;
    public List<Customer> Customers { get; set; }

    private DataOperations()
    {
        Customers = BogusOperations.CustomersList();
    }
}
