using FluentValidation;
using System.Runtime.CompilerServices;
using DapperLibrary1.LanguageExtensions;
#pragma warning disable CA2255

namespace DapperLibrary1.Classes;
internal class FluidSetup
{
    [ModuleInitializer]
    public static void Init()
    {

        // Set up FluentValidation for .WithName
        ValidatorOptions.Global.DisplayNameResolver = (type, memberInfo, expression) =>
            ValidatorOptions.Global.PropertyNameResolver(type, memberInfo, expression)
                .SplitPascalCase();
    }
}
