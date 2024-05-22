#pragma warning disable CS8618 
using System.ComponentModel.DataAnnotations;

namespace ConditionalBreakpointsSample.Models;

public class Customer
{
    public int Id { get; set; }
    [Display(Name = "First")]
    public string FirstName { get; set; }
    [Display(Name = "Last")]
    public string LastName { get; set; }
    [Display(Name = "Birth")]
    public DateOnly BirthDay { get; set; }

    public string Email { get; set; }

    public Gender? Gender { get; set; }

    public Customer()
    {

    }

    public Customer(int id)
    {
        Id = id;
    }
}