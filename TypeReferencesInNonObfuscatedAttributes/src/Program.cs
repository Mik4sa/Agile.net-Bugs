using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Http.Description;

namespace TypeReferencesInNonObfuscatedAttributes
{
    internal class Program
    {
        private static void Main()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            CultureInfo.CurrentUICulture = new CultureInfo("en-US");

            MethodInfo getStringMethodInfo = typeof(Class1).GetMethods().First();
            List<Attribute> attributes = getStringMethodInfo.GetCustomAttributes(false).Cast<Attribute>().ToList(); // This is crashing


            // All should print the obfuscated type name
            IList<CustomAttributeData> attributesData = getStringMethodInfo.GetCustomAttributesData();
            Console.WriteLine(attributesData[0].ConstructorArguments.First().Value);
            Console.WriteLine(attributesData[1].ConstructorArguments.First().Value);
            Console.WriteLine(attributesData[2].ConstructorArguments.Last().Value);


            Console.WriteLine();
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }


    internal class Class1
    {
        [ResponseType(typeof(Class2))]
        [ResponseType(typeof(List<Class2>))]
        [SwaggerResponse(HttpStatusCode.OK, "A string", typeof(Class2))]
        public string GetString()
        {
            return default;
        }
    }

    internal class Class2
    {

    }
}
