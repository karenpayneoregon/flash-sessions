﻿using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace SomeLibraryFrontEnd;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample: abstract keyword";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
