using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AttributesWithNullArrayArgument
{
    internal class Program
    {
        private static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");

            List<Attribute> attributes = typeof(Class1).GetCustomAttributes(false).Cast<Attribute>().ToList(); // This is crashing

            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }

    [Custom(null)]
    [Custom(new int[] { })]
    [Custom(new int[] { 123 })]
    internal class Class1
    {

    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    internal class CustomAttribute : Attribute
    {
        public CustomAttribute(int[] array)
        {
        }
    }
}
