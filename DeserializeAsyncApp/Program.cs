using DeserializeAsyncApp.Classes;
using DeserializeAsyncApp.Models;
using static System.Globalization.DateTimeFormatInfo;

namespace DeserializeAsyncApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
  
        var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(2));

        var url = "https://raw.githubusercontent.com/karenpayneoregon/jsonfiles/main/Customers.json";

        var list = await JsonHelpers.ReadJsonAsync<Customer>(url, cancellationTokenSource.Token);
        var list1 = await JsonHelpers.ReadJsonWithTimeOutAsync<Customer>(url);
        var first = await JsonHelpers.ReadJson_Async<Customer>(url, cancellationTokenSource.Token);

        await ReadCustomersAsyncExample();
        Console.ReadLine();
    }


    private static async Task ReadCustomersAsyncExample()
    {
        List<Customer> customers = await JsonHelpers.ReadJson1Async<Customer>("Customers.json");

        foreach (var (customer, index) in customers.Select((item, index) => (item, index)))
        {
            Console.WriteLine($"{index,-5}{customer.Id,-5}{customer.Company,-40}{customer.Contact}");
        }

        Console.WriteLine();

        foreach (var item in customers.Select((customer, index) => new { index, customer }))
        {
            Console.WriteLine($"{item.index,-5}{item.customer.Id,-5}{item.customer.Company,-40}{item.customer.Contact}");
        }

        {
            Console.WriteLine();
            var index = 0;
            foreach (var customer in await JsonHelpers.ReadJson1Async<Customer>("Customers.json"))
            {
                index++;
                Console.WriteLine($"{index,-5}{customer.Id,-5} {customer.Company,-40}{customer.Contact}");
            }
        }



    }

    
}

