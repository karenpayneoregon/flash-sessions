using Week2BlankSlateApp.Classes;
using Week2BlankSlateApp.Interfaces;

namespace Week2BlankSlateApp.Models;

internal class Russian : IHuman
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public Language Language => Language.Russian;
    public string SayTimeOfDay
        => Language.SayHello();
}