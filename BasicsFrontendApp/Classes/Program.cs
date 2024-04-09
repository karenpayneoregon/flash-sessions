using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace BasicsFrontendApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Basic interfaces and classes examples";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
