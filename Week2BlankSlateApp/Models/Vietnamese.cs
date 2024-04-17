using Week2BlankSlateApp.Classes;
using Week2BlankSlateApp.Interfaces;

namespace Week2BlankSlateApp.Models;

internal class Vietnamese : IHuman
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public Language Language => Language.Vietnamese;
    public string SayTimeOfDay
        => Language.SayHello();
}