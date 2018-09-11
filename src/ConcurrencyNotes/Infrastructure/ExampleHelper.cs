using ConcurrencyNotes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyNotes.Infrastructure
{
    public static class ExampleHelper
    {
        public static async void Run<T>(T exampleType) where T : Type
        {
            try
            {
                await Execute(exampleType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async Task Execute<T>(T exampleType) where T : Type
        {
            if (exampleType == null)
                throw new ArgumentNullException(nameof(exampleType), "Argument can't be null");


            var instance = Activator.CreateInstance(exampleType) as IThreadExample;


            if (instance == null)
                throw new InvalidCastException("Example should be inherited from IThreadExample");


            if (instance is ISingleThreadExample)
                ((ISingleThreadExample)instance).Execute();

            else if (instance is ISyncAsyncThreadExample)
            {
                ISyncAsyncThreadExample example = instance as ISyncAsyncThreadExample;

                await example.StartAsync();
                await example.StartSync();
            }
        }
    }
}
