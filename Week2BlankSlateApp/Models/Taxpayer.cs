using Week2BlankSlateApp.Classes;
using Week2BlankSlateApp.Interfaces;

namespace Week2BlankSlateApp.Models;

public class Taxpayer : IHuman
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public Language Language => Language.Netural;
    public string SayTimeOfDay
        => Language.SayHello();
}