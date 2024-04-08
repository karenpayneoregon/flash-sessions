#nullable disable

/*
 * There are several classes in this file, for a real
 * project, one class/model per file.
 */

using static System.DateTime;

namespace SomeLibrary1.Models;


/// <summary>
/// Recognized spoken languages for <see cref="Howdy"/> methods.
/// </summary>
public enum Language
{
    American,
    Russian
}

/// <summary>
/// Provides a method to say hello in different languages.
/// </summary>
public class Howdy
{
    public static string SayHello(Language language) =>
        /*
         * This is a switch expression which should only be used when
         * an entire team understand them.
         */
        language switch
        {
            Language.American => AmericanTimeOfDay(),
            Language.Russian => RussianTimeOfDay(),
            _ => throw new ArgumentOutOfRangeException(nameof(language), language, null)
        };


    /*
     * The following two methods use switch expressions.
     */

    /// <summary>
    /// Say time of day in English
    /// </summary>
    /// <returns>a string saying a greeting for time of day in English</returns>
    public static string AmericanTimeOfDay() => Now.Hour switch
    {
        <= 12 => "Good Morning",
        <= 16 => "Good Afternoon",
        <= 20 => "Good Evening",
        _     => "Good Night"
    };

    /// <summary>
    /// Say time of day in Russian
    /// </summary>
    /// <returns>a string saying a greeting for time of day in Russian</returns>
    public static string RussianTimeOfDay() => Now.Hour switch
    {
        <= 12 => "dobroye utro",
        <= 16 => "dobryy den'",
        <= 20 => "dobryy vecher",
        _     => "Spokoynoy nochi"
    };
}