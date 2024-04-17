#nullable disable
using SomeLibrary1.Interfaces;
using static SomeLibrary1.Models.Howdy;

/*
 * There are several classes in this file, for a real
 * project, one class/model per file.
 */

namespace SomeLibrary1.Models;

public abstract class Human
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    protected abstract Language Language { get; }
    public abstract string SayTimeOfDay { get; }
    public override string ToString() => $"{FirstName}";

}

public class American : Human, IFood
{
    protected override Language Language => Language.American;

    public override string SayTimeOfDay
        => SayHello(Language);

    public string Drink { get; set; } = "Beer";
}

public class Russian : Human, IFood
{
    protected override Language Language => Language.Russian;

    public override string SayTimeOfDay
        => SayHello(Language);

    public string Drink { get; set; } = "Vodka";
}