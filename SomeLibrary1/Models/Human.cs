#nullable disable
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
        public abstract string SayTimeOfDay { get; }
    }

    public class American : Human
    {
        public override string SayTimeOfDay 
            => SayHello(Language.American);
    }

    public class Russian : Human
    {
        public override string SayTimeOfDay 
            => SayHello(Language.Russian);
    }