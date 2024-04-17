using BasicLibrary.Interfaces;

namespace BasicLibrary.Models;

public class Person : IHuman
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    
    public DateOnly BirthDate { get; set; }

    public Gender Gender { get; set; }
}