#nullable disable

using static System.DateTime;

namespace Week2BlankSlateApp.Classes;

/// <summary>
/// Provides a method to say hello in different languages.
/// </summary>
public static class Howdy
{
    /// <summary>
    /// Say hello in different languages.
    /// </summary>
    /// <param name="language"><see cref="Language"/></param>
    /// <returns>Greeting for time of day</returns>
    public static string SayHello(this Language language) =>
        /*
         * 💡 This is a switch expression which should only be used when
         * an entire team understand them.
         */
        language switch
        {
            Language.American   => AmericanTimeOfDay(),
            Language.Netural    => AmericanTimeOfDay(),
            Language.Russian    => RussianTimeOfDay(),
            Language.Vietnamese => VietnameseTimeOfDay(),
            _ => "Unknown language" // could throw an exception instead
        };


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

    /// <summary>
    /// Say time of day in Russian
    /// </summary>
    /// <returns>a string saying a greeting for time of day in Russian</returns>
    public static string VietnameseTimeOfDay() => Now.Hour switch
    {
        <= 12 => "Chào buổi sáng",
        <= 16 => "Cha\u0300o buô\u0309i chiê\u0300u",
        <= 20 => "Chào buổi tối",
        _ => "Chúc ngủ ngon"
    };
}