using ConditionalBreakpointsSample.Classes;
using ConditionalBreakpointsSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace ConditionalBreakpointsSample.Pages;
public class IndexModel : PageModel
{

    [BindProperty]
    public List<Customer> Customers { get; set; } = null!;

    public void OnGet()
    {
        Customers = DataOperations.Instance.Customers;
    }

    public void OnPostDemo()
    {
        

        Customers = DataOperations.Instance.Customers;

        foreach (var customer in Customers)
        {
            
        }


        for (int rowIndex = 0; rowIndex < Customers.Count; rowIndex++)
        {
            
        }
    }
}
