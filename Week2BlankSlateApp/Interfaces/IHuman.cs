using Week2BlankSlateApp.Classes;

namespace Week2BlankSlateApp.Interfaces;

public interface IHuman
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    protected Language Language { get; }
    public string Hello { get; }
}