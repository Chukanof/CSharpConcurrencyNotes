using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyNotes.Infrastructure
{
    public static class ExamplesExtension
    {
        public static Type GetExampleType(this Examples example, string suffix = "Example")
        {
            var typeName = example.ToString() + suffix;

            var assembly = Assembly.GetExecutingAssembly();

            var result = assembly
                .DefinedTypes
                .FirstOrDefault(x => x.Name == typeName);

            return result;
        }
    }
}
