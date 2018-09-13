using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyNotes.Examples.Exceptions
{
    class _01_AsyncCatchExceptionsExample : ISingleExample
    {
        public void Execute()
        {
            var task = Task.Run(() => throw new NotImplementedException());
            try
            {
                task.Wait();
            }
            catch (Exception aex)
            {
                if (aex.InnerException is NotImplementedException)
                    Console.WriteLine($"{nameof(NotImplementedException)} is catched");
                else
                    throw;
            }
        }
    }
}
